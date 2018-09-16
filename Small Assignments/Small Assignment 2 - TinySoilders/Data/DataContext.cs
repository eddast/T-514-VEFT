using template.Models;
using System.Collections.Generic;
using System.Linq;

namespace template.Data
{
    public static class DataContext
    {
        private static List<Model> _models = new List<Model> 
        {
            new Model
            {
                Id = 1,
                Name = "Lord-Celestant on Stardrake",
                NameDE = "Lord Celestant auf Stardrake",
                Race = "Stormcast Eternals",
                RaceDE = "Stormcast Eternals",
                Price = 140,
                Description = "Even amongst the gloried ranks of the Stormcast Eternals and the star-born hierarchy of the Children of Dracothion, only the mightiest and noblest are chosen to lead an Extremis Chamber. So infused with celestial power are the Lord-Celestant and Stardrake that they radiate azure energies. The power of the stars themselves is theirs to command…",
                DescriptionDE = "Selbst aus den ruhmreichen Rängen der Stormcast Eternals und der sterngeborenen Hierarchie der Kinder des Dracothion werden nur die mächtigsten und edelsten erwählt, eine Extremis Chamber anzuführen. So erfüllt mit himmlischer Energie sind Lord-Celestant und Stardrake, dass sie azurblaue Energien ausstrahlen. Die Macht der Sterne selbst gehorcht ihrem Willen. Dieser mehrteilige Kunststoffbausatz enthält alle Teile, die du benötigst, um eines der beiden folgenden Modelle zu bauen: Einen Lord-Celestant auf Stardrake, der die Extremis Chamber anführt und über die Macht der Sterne selbst gebietet und entweder mit einem Tempestos Hammer oder mit Stormbound Blade und Sigmarite-Schild bewaffnet ist, oder einen Drakesworn Templar, die gestaltgewordene Vergeltung der Himmel, die entweder mit Tempest Axe, Arc Hammer oder Stormlance und Skybolt Bow bewaffnet ist.",
                Rarity = 50,
                DifficultyLevel = "Advanced",
                DifficultyLevelDE = "Fortgeschritten",
                YearOfRelease = 2016,
                ImageUrl = "https://www.games-workshop.com/resources/catalog/product/920x950/99120218008_StormcastStardrake01.jpg"
            },
            new Model
            {
                Id = 2,
                Name = "Celestant-Prime",
                NameDE = "Celestant-Prime",
                Race = "Stormcast Eternals",
                RaceDE = "Stormcast Eternals",
                Price = 80,
                Description = "The wrath of the God-King. The Avenging Angel of Azyr. The Bearer of the World-Hammer. The First Scion of Sigmar - this is the Celestant-Prime. A great king and guardian of men even in mortal life, he has been strengthened by a prodigious infusion of Sigmar’s divine might; but even this power was not enough. Now wielding the Skull Splitter, the Great Shatterer Ghal Maraz, the Celestant-Prime’s fury roars across the battlefields of the realms as an overwhelming clarion call. The thunderous impact of Ghal Maraz can slay a daemon with one blow, setting the spirit within free to make its way to Azyr.",
                DescriptionDE = "Der Zorn des Gottkönigs. Der Racheengel Azyrs. Der Träger des Weltenhammers. Der Erste Sohn Sigmars – dies ist der Celestant-Prime. Er, der schon im sterblichen Leben ein großer König und Wächter über die Menschen war, wurde durch die gewaltige Erfüllung mit Sigmars göttlicher Macht gestärkt; aber selbst diese reichte nicht aus. Nun, da er den Schädelspalter, den Großen Zerschmetterer Ghal Maraz trägt, ist der Zorn des Celestant-Prime auf den Schlachtfeldern der Reiche als überwältigender Weckruf zu vernehmen. Der donnernde Einschlag von Ghal Maraz vermag einen Dämon mit einem einzigen Schlag zu töten und befreit den Geist im Inneren, der dann nach Azyr aufsteigen kann.",
                Rarity = 25,
                DifficultyLevel = "Intermediate",
                DifficultyLevelDE = "Mittlere",
                YearOfRelease = 2017,
                ImageUrl = "https://www.games-workshop.com/resources/catalog/product/920x950/99120218001_CelestantPrime01.jpg"
            },
            new Model
            {
                Id = 3,
                Name = "Megaboss on Maw-krusha",
                NameDE = "Megaboss auf Maw-krusha",
                Race = "Orruk",
                RaceDE = "Orruk",
                Price = 110,
                Description = "Orruk Megabosses are pretty killy – it’s how they become as huge as they do, all that stompin’ causes them to grow and grow and grow until the power of the Waaagh! flows through them. But for some Megabosses, this isn’t enough! These particularly angry orruks seek out and subdue enormous Maw-krushas (often by yelling really, really loudly at them) – ill-tempered and powerful creatures who enjoy smashing stuff up almost as much as the orruks themselves. This uneasy pairing never really gets along especially well, and the Megaboss needs to constantly remind his Maw-krusha who’s in charge with the liberal application of an iron boot to the back of the head. Despite this, almost nothing on the battlefield can withstand their noisy rampage, and the immense number of kills they rack up inspires nearby orruks to fight ever harder.",
                DescriptionDE = "Megabosse der Orruks sind ziemlich moschig – nur so werden sie so groß, wie sie sind, denn all das Stampf'n lässt sie wachsen und wachsen, bis die Macht des Waaagh sie durchströmt. Für manche Megabosse ist das jedoch nicht genug. Diese besonders wütenden Orruks suchen und unterwerfen sich gewaltige Maw-krushas (oft indem sie diese sehr sehr laut anbrüllen) – übellaunige und überaus starke Kreaturen, die es beinahe ebenso sehr genießen, Zeug zu zerschmettern, wie die Orruks selbst. Dieses spannungsgeladene Paar kommt selten besonders gut miteinander aus, und so muss der Megaboss den Maw-krusha immer wieder daran erinnern, wer das Sagen hat, indem er ihm beherzt mit einem eisernen Stiefel gegen den HInterkopf tritt. Dennoch kann fast nichts auf dem Schlachtfeld ihrem lautstarken Ansturm widerstehen, und die immense Anzahl an Tötungen, die sie anhäufen, inspiriert die Orruks in der Nähe dazu, noch härter zu kämpfen.",
                Rarity = 40,
                DifficultyLevel = "Advanced",
                DifficultyLevelDE = "Fortgeschritten",
                YearOfRelease = 2014,
                ImageUrl = "https://www.games-workshop.com/resources/catalog/product/920x950/99120209032_MawKrusha01.jpg"
            },
            new Model
            {
                Id = 4,
                Name = "Gore-gruntas",
                NameDE = "Gore-gruntas",
                Race = "Orruk",
                RaceDE = "Orruk",
                Price = 79,
                Description = "Enormous, foul-tempered porcine beasts of a strength and fury that even orruks respect, gruntas trample down all but the biggest foe, devouring the remains and noisily smashing apart everything in their path – much to the vivid delight of the Ironjawz who bounce gleefully upon their somewhat interestingly-fragranced backs. Gruntas will cheerfully and greedily eat anything, including iron (the result of devouring people wearing it, more often than not.) This undigested metal is harvested by orruks for use as weapons and armour, and called pig-iron. A well-timed charge of Gore-gruntas can easily smash apart an enemy army in a riot of stomping hooves, piercing tusks and unpleasant smells.",
                DescriptionDE = "Gruntas sind riesige, übellaunige Schweinebestien, die über eine Stärke und Wut verfügen, die selbst die Orruks respektieren, und sie trampeln selbst größte Feinde nieder, verschlingen die Überreste und zerfetzen mit viel Lärm alles, was ihnen im Wege steht, ganz zur Freude der Ironjawz, die fröhlich auf ihren – sagen wir interessant – riechenden Rücken herumspringen. Gruntas fressen fröhlich und gierig alles, auch eiserne Rüstungsteile (oft als Nebenwirkung des Verzehrs von Feinden, die sich darin befinden). Dieses unverdaute Metall wird von den Orruks für die Herstellung von Waffen und Rüstung eingesammelt und ist als Schweineeisen bekannt. Ein Angriff der Gore-gruntas zur rechten Zeit kann mit Leichtigkeit eine feindliche Armee in einem Durcheinander aus stampfenden Hufen, aufspießenden Hauern und unangenehmen Gerüchen vernichten.",
                Rarity = 10,
                DifficultyLevel = "Intermediate",
                DifficultyLevelDE = "Mittlere",
                YearOfRelease = 2014,
                ImageUrl = "https://www.games-workshop.com/resources/catalog/product/920x950/99120209031_GoreGruntaz01.jpg"
            },
            new Model
            {
                Id = 5,
                Name = "Thanquol & Boneripper",
                NameDE = "Thanquol und Boneripper",
                Race = "Skaven",
                RaceDE = "Skaven",
                Price = 77,
                Description = "Thanquol is a grey seer of prodigious ability (some would say luck) who is watched over by his sturdy and loyal, albeit mindless, bodyguard Boneripper. They make a fearsome duo; the arcane might of Thanquol complimenting the savage brawn of his giant rat ogre. This imposing multipart plastic kit makes one Thanquol and Boneripper. Thanquol himself is armed with the Staff of the Horned Rat (with his unique rune carved into it), and wears a warp-amulet. Boneripper is a gigantic mutated four-armed rat ogre, covered in brands, stitched-up skin and rune-etched armour. He has a massive power pack on his back and sports a mechanical left leg. He comes with 2 variant heads and can be armed with either a warpfire projectors or warpfire braziers. There is also the option to add a alternate shoulder spike should you wish.",
                DescriptionDE = "Thanquol ist ein Grey Seer, der über ungeheure Fähigkeiten (manche würden sagen: Glück) verfügt und von seinem standhaften und treuen, wenn auch dummen Leibwächter Boneripper beschützt wird. Sie sind ein furchterregendes Duo; Thanquols arkane Macht ergänzt die wilde Muskelkraft seines riesigen Rattenogers perfekt. Aus diesem beeindruckenden mehrteiligen Kunststoffbausatz lassen sich Thanquol und Boneripper bauen. Thanquol selbst ist mit dem Stab der Gehörnten Ratte bewaffnet (in den seine einzigartige Rune eingeschnitzt ist) und trägt ein Amulett der Gehörnten. Boneripper ist ein riesiger, mutierter Rattenoger mit vier Armen, Brandzeichen, zusammengenähter Haut und runengeätzter Rüstung. Auf dem Rücken trägt er einen riesigen Energiegenerator, außerdem hat er ein mechanisches linkes Bein. Du hast die Wahl zwischen zwei verschiedenen Köpfen und kann entweder mit Warpfeuerprojektoren oder Warpfeuerbrennern bewaffnet werden. Ferner hast du die Möglichkeit, einen alternativen Schulterstachel hinzuzufügen, wenn du dies wünschst.",
                Rarity = 40,
                DifficultyLevel = "Advanced",
                DifficultyLevelDE = "Fortgeschritten",
                YearOfRelease = 2016,
                ImageUrl = "https://www.games-workshop.com/resources/catalog/product/920x950/99120206019_ThanquolBoneripper01.jpg"
            },
            new Model
            {
                Id = 6,
                Name = "Stormvermin",
                NameDE = "Sturmratten der Skaven",
                Race = "Skaven",
                RaceDE = "Skaven",
                Price = 49.50,
                Description = "The Stormvermin are the fighting elite of the Skaven warlord clans. They are distinguishable from lesser Skaven by their thick muscular necks and powerful build. Largest and most aggressive of the Skaven, Stormvermin regiments are outfitted with the best gear of war in the clan's armoury and their duties may include forming a retinue bodyguard for anyone from a minor clan Chieftain to the mighty ruling Clan Warlord himself.",
                DescriptionDE = "Die Sturmratten sind die kämpfende Elite der kriegerischen Klane der Skaven. Sie lassen sich leicht von ihren abgemagerten kleineren \"Kameraden\" durch ihre starke Nackenmuskulatur und kräftige Statur unterscheiden. Als die größten und aggressivsten aller Skaven, werden die Sturmratten mit den besten Waffen ausgestattet die sich in den Rüstkammern des Klans finden lassen, und zu ihren Pflichten gehört es das Gefolge oder die Leibwache vom kleinen Häuptling bis zum mächtigsten Kriegsherren zu stellen.",
                Rarity = 1,
                DifficultyLevel = "Beginner",
                DifficultyLevelDE = "Anfänger",
                YearOfRelease = 2005,
                ImageUrl = "https://www.games-workshop.com/resources/catalog/product/920x950/99120206008_StormverminNEW01.jpg"
            },
            new Model
            {
                Id = 7,
                Name = "Leadbelchers",
                NameDE = "Leadbelchers",
                Race = "Ogor",
                RaceDE = "Ogor",
                Price = 40,
                Description = "Leadbelchers are generally regarded as unhinged by most other Ogors, but also highly entertaining. They are obsessed with destruction and noise, and arm themselves with great portable Leadbelcher guns. Before battle, Leadbelchers fill their gun's barrel with crude black powder, metal shot, rusty nails, an assortment of wickedly bladed weapons and even the occasional cannon ball. Suffice to say, their approach to warfare is unsubtle, though entirely effective. If a volley of fast-moving, sharp missiles doesn't kill their foe, then a quick beating with their guns should finish the job.",
                DescriptionDE = "Leadbelchers werden von den meisten anderen Ogors als seltsam erachtet, aber auch als sehr unterhaltsam. Sie sind von Zerstörung und Lärm besessen und bewaffnen sich mit großen, tragbaren Leadbelcher Guns. Vor der Schlacht stopfen die Leadbelchers Schwarzpulver, Metallgeschosse, rostige Nägel, diverse höllisch scharfe Klingen und manchmal gar Kanonenkugeln in die Rohre ihrer Waffen. Ihre Art Krieg zu führen ist wenig subtil, dafür aber sehr wirkungsvoll. Wenn eine Salve rasend schneller, scharfer Geschosse den Feind nicht umbringt, dann gelingt dies meist einer Tracht Prügel mit einem schweren Kanonenrohr.",
                Rarity = 5,
                DifficultyLevel = "Beginner",
                DifficultyLevelDE = "Anfänger",
                YearOfRelease = 2003,
                ImageUrl = "https://www.games-workshop.com/resources/catalog/product/920x950/99120213013_LeadbelchersNEW01.jpg"
            },
            new Model
            {
                Id = 8,
                Name = "Firebelly",
                NameDE = "Firebelly",
                Race = "Ogor",
                RaceDE = "Ogor",
                Price = 40,
                Description = "Worshippers of ash and flame, volcano and magma, the Firebellies revere Gorkamorka as the Sun‑eater. Firebellies consume burning combustibles in sorcerous rituals so that they might honour their god by belching fire over their enemies.",
                DescriptionDE = "Die Firebellies beten Asche und Flamme an, Vulkan und Magma, und sie verehren Gorkamorka als den Sonnenfresser. Firebellies fressen in magischen Ritualen glühende Brennstoffe, damit sie ihren Gott ehren können, indem sie Feuer auf ihre Feinde rülpsen.",
                Rarity = 15,
                DifficultyLevel = "Intermediate",
                DifficultyLevelDE = "Mittlere",
                YearOfRelease = 2014,
                ImageUrl = "https://www.games-workshop.com/resources/catalog/product/920x950/99810213004_FirebellyNEW01.jpg"
            },
            new Model
            {
                Id = 9,
                Name = "Skink Starpriest",
                NameDE = "Skink Starpriest",
                Race = "Seraphon",
                RaceDE = "Seraphon",
                Price = 20,
                Description = "Some within the ranks of the seraphon are naturally gifted with intellects far superior to other mortals - the Skink Starpriests are definitive examples of this. Akin to wizards of other races, they excel in the ability to cast down the potent destructive energies of Azyr, burning up their enemies in scything beams of light summoned from a distant star.",
                DescriptionDE = "Manche unter den Seraphon sind mit einem Intellekt gesegnet, der den anderer Sterblicher weit übersteigt. Skink Starpriests sind solche Wesen. In ihrem Volk nehmen sie die Rolle ein, die Zauberer bei anderen Völkern haben. Sie verstehen sich darauf, die mächtigen zerstörerischen Energien Azyrs heraufzubeschwören, um etwa Feinde durch die Lichtstrahlen eines fernen Sterns zu verbrennen.",
                Rarity = 1,
                DifficultyLevel = "Beginner",
                DifficultyLevelDE = "Anfänger",
                YearOfRelease = 2005,
                ImageUrl = "https://www.games-workshop.com/resources/catalog/product/920x950/99070208003_SkinkStarpriest01.jpg"
            },
            new Model
            {
                Id = 10,
                Name = "Slann Starmaster",
                NameDE = "Slann Starmaster",
                Race = "Seraphon",
                RaceDE = "Seraphon",
                Price = 50,
                Description = "Few creatures have mastered the secrets of pure magic like the slann. Their aeons of travel amongst the stars have saturated their minds and bodies with the shimmering power of Azyr - as they glide into battle atop their graven thrones, incredible, crackling energies thrum around their fingertips, promising the unleashing of incredible spells. Many of these spells concentrate on strengthening the Starmaster’s fellow warriors, invigorating them with Azyrite power or transporting them across the theatre of battle. A seraphon army with a Starmaster at its heart is never truly defeated - this ancient wizard can summon fresh warriors to his aid with a mere thought.",
                DescriptionDE = "Nur wenige Wesen haben die Geheimnisse der reinen Magie so sehr gemeistert wie die Slann. Auf ihren äonenlangen Reisen zwischen den Sternen hat die schimmernde Macht Azyrs ihre Geister und Körper durchdrungen. Wenn sie nun auf ihren Steinthronen in die Schlacht schweben, umspielen unermessliche Energien knisternd ihre Fingerspitzen und lassen Zauber von unglaublicher Macht erwarten. Viele dieser Zauber unterstützen die Krieger des Starmasters, indem sie diese durch die Kraft Azyrs stärken oder sie über das Schlachtfeld transportieren. Eine Seraphon-Armee mit einem Starmaster kann niemals wirklich besiegt werden, denn der uralte Zauberer kann mit einem bloßen Gedanken frische Krieger herbeirufen.",
                Rarity = 25,
                DifficultyLevel = "Advanced",
                DifficultyLevelDE = "Fortgeschritten",
                YearOfRelease = 2015,
                ImageUrl = "https://www.games-workshop.com/resources/catalog/product/920x950/99810208028_SlannStarMaster01.jpg"
            }
        };
        public static List<Model> Models { get => _models; set => _models = value; }
    }
}