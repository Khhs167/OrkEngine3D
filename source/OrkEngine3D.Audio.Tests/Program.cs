// See https://aka.ms/new-console-template for more information

using OrkEngine3D.Audio;
using OrkEngine3D.Graphics.TK.Resources;

Console.WriteLine("Hello, World!");
ID source = AudioApi.CreateTrack("../../../organfinale.wav");
AudioApi.Play(source);
Console.ReadKey();