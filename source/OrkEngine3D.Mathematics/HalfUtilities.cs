/*
* Copyright (c) 2007-2010 SlimDX Group
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace OrkEngine3D.Mathematics;

/// <summary>
/// Helper class to perform Half/Float conversion.
/// </summary>
internal static class HalfUtilities
{
    //Source: www.fox-toolkit.org/ftp/fasthalffloatconversion.pdf by Jeroen van der Zijp
    static readonly uint[] HalfToFloatMantissaTable = new uint[2048];
    static readonly uint[] HalfToFloatExponentTable = new uint[64];
    static readonly uint[] HalfToFloatOffsetTable = new uint[64];
    static readonly ushort[] FloatToHalfBaseTable = new ushort[512];
    static readonly byte[] FloatToHalfShiftTable = new byte[512];

    [StructLayout(LayoutKind.Explicit)]
    private struct FloatToUint
    {
        [FieldOffset(0)]
        public uint uintValue;

        [FieldOffset(0)]
        public float floatValue;
    }

    static HalfUtilities()
    {
        int i;

        //Mantissa table

        //0 => 0
        HalfToFloatMantissaTable[0] = 0;

        //Transform subnormal to normalized
        for (i = 1; i < 1024; i++)
        {
            uint m = ((uint)i) << 13;
            uint e = 0;

            while ((m & 0x00800000) == 0)
            {
                e -= 0x00800000;
                m <<= 1;
            }

            m &= ~0x00800000U;
            e += 0x38800000;
            HalfToFloatMantissaTable[i] = m | e;
        }

        //Normal case
        for (i = 1024; i < 2048; i++)
            HalfToFloatMantissaTable[i] = 0x38000000 + (((uint)(i - 1024)) << 13);

        //Exponent table

        //0 => 0
        HalfToFloatExponentTable[0] = 0;

        for (i = 1; i < 63; i++)
        {
            if (i < 31)
            {
                //Positive Numbers
                HalfToFloatExponentTable[i] = ((uint)i) << 23;
            }
            else
            {
                //Negative Numbers
                HalfToFloatExponentTable[i] = 0x80000000 + (((uint)(i - 32)) << 23);
            }
        }
        HalfToFloatExponentTable[31] = 0x47800000;
        HalfToFloatExponentTable[32] = 0x80000000;
        HalfToFloatExponentTable[63] = 0xC7800000;

        //Offset table
        HalfToFloatOffsetTable[0] = 0;
        for (i = 1; i < 64; i++)
            HalfToFloatOffsetTable[i] = 1024;
        HalfToFloatOffsetTable[32] = 0;

        //Float to Half tables
        for (i = 0; i < 256; i++)
        {
            int e = i - 127;
            if (e < -24)
            {
                //Very small numbers map to zero
                FloatToHalfBaseTable[i | 0x000] = 0x0000;
                FloatToHalfBaseTable[i | 0x100] = 0x8000;
                FloatToHalfShiftTable[i | 0x000] = 24;
                FloatToHalfShiftTable[i | 0x100] = 24;
            }
            else if (e < -14)
            {
                //Small numbers map to denorms
                FloatToHalfBaseTable[i | 0x000] = (ushort)((0x0400 >> (-e - 14)));
                FloatToHalfBaseTable[i | 0x100] = (ushort)((0x0400 >> (-e - 14)) | 0x8000);
                FloatToHalfShiftTable[i | 0x000] = (byte)(-e - 1);
                FloatToHalfShiftTable[i | 0x100] = (byte)(-e - 1);
            }
            else if (e <= 15)
            {
                //Normal numbers just lose precision
                FloatToHalfBaseTable[i | 0x000] = (ushort)(((e + 15) << 10));
                FloatToHalfBaseTable[i | 0x100] = (ushort)(((e + 15) << 10) | 0x8000);
                FloatToHalfShiftTable[i | 0x000] = 13;
                FloatToHalfShiftTable[i | 0x100] = 13;
            }
            else if (e < 128)
            {
                //Large numbers map to Infinity
                FloatToHalfBaseTable[i | 0x000] = 0x7C00;
                FloatToHalfBaseTable[i | 0x100] = 0xFC00;
                FloatToHalfShiftTable[i | 0x000] = 24;
                FloatToHalfShiftTable[i | 0x100] = 24;
            }
            else
            {
                //Infinity and NaN's stay Infinity and NaN's
                FloatToHalfBaseTable[i | 0x000] = 0x7C00;
                FloatToHalfBaseTable[i | 0x100] = 0xFC00;
                FloatToHalfShiftTable[i | 0x000] = 13;
                FloatToHalfShiftTable[i | 0x100] = 13;
            }
        }
    }

    /// <summary>
    /// Unpacks the specified half.
    /// </summary>
    /// <param name="value">The half to unpack.</param>
    /// <returns>The floating point representation of the half.</returns>
    public static float Unpack(ushort value)
    {
        var conv = new FloatToUint();
        conv.uintValue = HalfToFloatMantissaTable[HalfToFloatOffsetTable[value >> 10] + (((uint)value) & 0x3ff)] + HalfToFloatExponentTable[value >> 10];
        return conv.floatValue;
    }

    /// <summary>
    /// Packs the specified float.
    /// </summary>
    /// <param name="value">The float to pack.</param>
    /// <returns>The half represntation of the float.</returns>
    public static ushort Pack(float value)
    {
        FloatToUint conv = new FloatToUint();
        conv.floatValue = value;
        return (ushort)(FloatToHalfBaseTable[(conv.uintValue >> 23) & 0x1ff] + ((conv.uintValue & 0x007fffff) >> FloatToHalfShiftTable[(conv.uintValue >> 23) & 0x1ff]));
    }
}
