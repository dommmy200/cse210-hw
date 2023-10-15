using System;
using System.Text.Json;
using MyWk05Design;

namespace Scripture1
{
    JObject scripture = new JObject(
    new JProperty("Genesis 1:28", "Be fruitful and multiply and fill the earth and subdue it, and have dominion over the fish of the sea and over the birds of the heavens and over every living thing that moves on the earth"),
    new JProperty("Exodus 14:14", "The Lord will fight for you; you need only to be still"),
    new JProperty("Deuteronomy 31:6", "Do not be afraid or terrified because of them, for the Lord your God goes with you; he will never leave you nor forsake you"),
    new JProperty("1 samuel 17:47", "The battle is the Lord's, and he will give all of you into our hands"),
    new JProperty("2 Chronicles 15:7", "But as for you, be strong and do not give up, for your work will be rewarded"),
    new JProperty("Psalm 46:10", "Be still, and know that I am God; I will be exalted among the nations, I will be exalted in the earth"),
    new JProperty("Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight"),
    new JProperty("Mosiah 2:17", "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellowbeings ye are only in the service of your God"),
    new JProperty("2 Nephi 9:51", "Wherefore, do not spend money for that which is of no worth, nor your labor for that which cannot satisfy"),
    new JProperty("Alma 7:24", "And see that ye have faith, hope, and charity, and then ye will always abound in good works"));

File.WriteAllText(@"c:\videogames.json", scripture.ToString());

// write JSON directly to a file
using (StreamWriter file = File.CreateText(@"c:\videogames.json"))
using (JsonTextWriter writer = new JsonTextWriter(file))
{
    scripture.WriteTo(writer);
}
}
