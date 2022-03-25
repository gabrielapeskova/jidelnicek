using System;
using System.Xml;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text;
using System.IO;

namespace jidelniček
{
    class Program
    {

        public System.Text.Encoding Encoding { get; set; }
        public static void NavratDoMenu()
        {
            Console.WriteLine("\nPro návrat do menu stiskněte libovolnou klávesu");
            Console.ReadKey();
            Console.Clear();
        }

        public static void spatnaHodnota()
        {
            Console.WriteLine("Uživatel zadal v dotazníku nesprávnou hodnotu, prosím načtěte spávná data");
        }
        
        static void Main(string[] args)
        {
            string cesta = "neznámá";
            XmlDocument xdoc = new XmlDocument();
            bool overeni = false;
            string jmeno = "neznámé";
            string pohlavi = "neznámé";
            double vek = 0;
            double vyska = 0;
            double vaha = 0;
            string zamestnani = "neznámé";
            string stres = "neznámý";
            double pocetChodu = 0;
            double sportTydne = 0;
            string druhSportu = "nezmámý";
            double delkaSportu = 0;
            string ucelDiety = "neznámý";
            double bazalniMetabolismus = 0;
            double sportKcal = 0;
            double zamestnaniKcal = 0;
            double stresKcal = 0;
            double traveniZtraty = 0;
            double traveniZtratySport = 0;
            double termodynamickyEfekt = 0;
            double termodynamickyEfektSport = 0;
            double kcalSportovniDen = 0;
            double kcalNesportovniDen = 0;
            double sacharidyKcal = 0;
            double tukyKcal = 0;
            double bilkovinyKcal = 0;
            double sacharidyg = 0;
            double tukyg = 0;
            double bilkovinyg = 0;
            double sacharidyKcalS = 0;
            double tukyKcalS = 0;
            double bilkovinyKcalS = 0;
            double sacharidygS = 0;
            double tukygS = 0;
            double bilkovinygS = 0;
            double a = 0;
            double b = 0;
            double c = 0;
            double snidane = 0;
            double svacina = 0;
            double obed = 0;
            double vecere = 0;
            double chod = 0;
            double snidaneS = 0;
            double svacinaS = 0;
            double obedS = 0;
            double vecereS = 0;
            double chodS = 0;
            char menu;
            do
            {
                Console.Clear();
                Console.WriteLine("Vyberte jednu z možností (pro výběr stisknětě příslušné číslo)");
                Console.WriteLine("1 Načíst nového klienta");
                Console.WriteLine("2 Výpočet bazálního metabolismu klienta");
                Console.WriteLine("3 Výpočet ideálního denního kalorického příjmu klienta");
                Console.WriteLine("4 Výpočet denní potřeby sacharidů, tuků a bílkovin");
                Console.WriteLine("5 Výpočet denního rozložení kalorií do jednotlivých chodů");
                Console.WriteLine("6 Export vypočtených hodnot do textového souboru");
                Console.WriteLine("7 Konec");

               //výpočet zákládního bazálního metabolismu 
               if (pohlavi == "žena")
               {
                 bazalniMetabolismus = 655.0935 + (9.6 * vaha) + (1.85 * vyska) - (6.8 * vek);
               }
               else if (pohlavi == "muž")
               {
                 bazalniMetabolismus = 66 + (13.7 * vaha) + (5 * vyska) - (6.8 * vek);
               }

                /*Výpočet ideálního denního kalorického příjmu složeného z výpočtu kcal bazálního*/
                /*metabolismu + stresu + termodynamického efektu + energetických ztrát z trávení + zaměstnání*/
                /* + sportovní aktivit + případné redukce kcal u redukční diety*/

                //Výpočet kcal spálené v zaměstnání
               if (zamestnani == "Sedavé (úředník, kancelář)")
                {
                    zamestnaniKcal = bazalniMetabolismus * 0.15;
                }
               else if (zamestnani == "středně aktivní (běžně manuálně pracující)")
                {
                    zamestnaniKcal = bazalniMetabolismus * 0.3;
                }
               else if (zamestnani == "vysoce fyzicky náročné (horník, dřevorubec)")
                {
                    zamestnaniKcal = bazalniMetabolismus * 0.45;
                }

                //výpočet kcal ze stresu//
               
               if (stres == "běžný pracovní a denní stres")
               {
                 stresKcal = bazalniMetabolismus * 0.08;
               }
               else if (stres == "zvýšený stres")
               {
                 stresKcal = bazalniMetabolismus * 0.14;
               }
               else if (stres == "mimořádný stres")
               {
                 stresKcal = bazalniMetabolismus * 0.22;
               }

                //Výpočet kcal spálených u sportovní aktivity
                if (druhSportu == "Chůze pomalá")
                {
                    sportKcal = 0.038 * vaha * delkaSportu;
                }
                else if (druhSportu == "Chůze rychlá")
                {
                    sportKcal = 0.0910 * vaha * delkaSportu;
                }
                else if (druhSportu == "Běh (pomalejší tempo)")
                {
                    sportKcal = 0.137 * vaha * delkaSportu;
                }
                else if (druhSportu == "Běh (rychlejší tempo)")
                {
                    sportKcal = 0.174 * vaha * delkaSportu;
                }
                else if (druhSportu == "Jízda na kole pomalá")
                {
                    sportKcal = 0.07 * vaha * delkaSportu;
                }
                else if (druhSportu == "Jízda na kole rychlá")
                {
                    sportKcal = 0.125 * vaha * delkaSportu;
                }
                else if (druhSportu == "Jóga")
                {
                    sportKcal = 0.062 * vaha * delkaSportu;
                }
                else if (druhSportu == "Kruhový trénink")
                {
                    sportKcal = 0.112 * vaha * delkaSportu;
                }
                else if (druhSportu == "Posilování")
                {
                    sportKcal = 0.113 * vaha * delkaSportu;
                }

                //Výpočet energetické ztráty trávením
                if (sportTydne > 0)
                {
                    traveniZtraty = 0.07 * (bazalniMetabolismus + zamestnaniKcal + stresKcal);
                    traveniZtratySport = 0.07 * (bazalniMetabolismus + zamestnaniKcal + stresKcal + sportKcal);
                }
                else
                {
                    traveniZtraty = 0.07 * (bazalniMetabolismus + zamestnaniKcal + stresKcal);
                }

                //Výpočet termodynamického efektu
                if (sportTydne > 0)
                {
                    termodynamickyEfekt = 0.07 * (bazalniMetabolismus + zamestnaniKcal + stresKcal);
                    termodynamickyEfektSport = 0.07 * (bazalniMetabolismus + zamestnaniKcal + stresKcal + sportKcal);
                }
                else
                {
                    termodynamickyEfekt = 0.07 * (bazalniMetabolismus + zamestnaniKcal + stresKcal);
                }

                //Výpočet ideálního příjmu ve sportovní den a den bez sportu

                kcalSportovniDen = bazalniMetabolismus + zamestnaniKcal + stresKcal + sportKcal + traveniZtratySport + termodynamickyEfektSport;
                kcalNesportovniDen = bazalniMetabolismus + zamestnaniKcal + stresKcal + traveniZtraty + termodynamickyEfekt;

                //Výpočet poměru sacharidy/tuky/bílkoviny pro jednotlivé účely diety
                if (ucelDiety == "Redukce váhy")
                {
                    kcalSportovniDen -= 400;
                    kcalNesportovniDen -= 400;
                    if (pohlavi == "žena")
                    {
                        a = 0.51;
                        b = 0.19;
                        c = 0.3;
                    }
                    else if (pohlavi == "muž")
                    {
                        a = 0.46;
                        b = 0.24;
                        c = 0.3;
                    }

                }
                else if (ucelDiety == "Udržovací jídelníček")
                {
                    a = 0.55;
                    b = 0.15;
                    c = 0.3;
                }
                else if (ucelDiety == "Zvýšení vytrvalostní výkonnosti")
                {
                    a = 0.7;
                    b = 0.12;
                    c = 0.18;
                }
                else if (ucelDiety == "Zvýšení silové výkonnosti")
                {
                    a = 0.55;
                    b = 0.3;
                    c = 0.15;
                }
                sacharidyKcal = a * kcalNesportovniDen;
                sacharidyg = sacharidyKcal / 4;
                bilkovinyKcal = b * kcalNesportovniDen;
                bilkovinyg = bilkovinyKcal / 4;
                tukyKcal = c * kcalNesportovniDen;
                tukyg = tukyKcal / 9;

                sacharidyKcalS = a * kcalSportovniDen;
                sacharidygS = sacharidyKcalS / 4;
                bilkovinyKcalS = b * kcalSportovniDen;
                bilkovinygS = bilkovinyKcalS / 4;
                tukyKcalS = c * kcalSportovniDen;
                tukygS = tukyKcalS / 9;

                //Výpočet rozložení kcal do jednotlivých chodů//
                if (pocetChodu == 2)
                {
                    chod = kcalNesportovniDen / 2;
                    chodS = kcalSportovniDen / 2;
                }
                else if (pocetChodu == 3)
                {
                    snidane = kcalNesportovniDen * 0.3;
                    snidaneS = kcalSportovniDen * 0.3;
                    obed = kcalNesportovniDen * 0.4;
                    obedS = kcalSportovniDen * 0.4;
                    vecere = kcalNesportovniDen * 0.3;
                    vecereS = kcalSportovniDen * 0.3;
                }
                else if (pocetChodu == 4)
                {
                    snidane = kcalNesportovniDen * 0.25;
                    snidaneS = kcalSportovniDen * 0.25;
                    obed = kcalNesportovniDen * 0.4;
                    obedS = kcalSportovniDen * 0.4;
                    svacina = kcalNesportovniDen * 0.1;
                    svacinaS = kcalSportovniDen * 0.1;
                    vecere = kcalNesportovniDen * 0.25;
                    vecereS = kcalSportovniDen * 0.25;
                }
                else if (pocetChodu == 5)
                {
                    snidane = kcalNesportovniDen * 0.2;
                    snidaneS = kcalSportovniDen * 0.2;
                    obed = kcalNesportovniDen * 0.4;
                    obedS = kcalSportovniDen * 0.4;
                    svacina = kcalNesportovniDen * 0.1;
                    svacinaS = kcalSportovniDen * 0.1;
                    vecere = kcalNesportovniDen * 0.2;
                    vecereS = kcalSportovniDen * 0.2;
                }

            menu = Console.ReadKey().KeyChar;
            Console.Clear(); 
            switch (menu)
            {
                case '1':
                    Console.WriteLine("Prosím zadejte cestu k souboru xml.\nNapříklad:C:\\Users\\Uživatel\\Desktop\\novyKlient.xml");
                    try
                    {
                     cesta = (Console.ReadLine());
                     xdoc.Load(cesta);
                     Console.Clear();
                            try
                            {
                                vek = Double.Parse(xdoc.SelectSingleNode("//klienti-data/klient/vek").InnerText);
                                vyska = Double.Parse(xdoc.SelectSingleNode("//klienti-data/klient/vyska").InnerText);
                                vaha = Double.Parse(xdoc.SelectSingleNode("//klienti-data/klient/vaha").InnerText);
                                pocetChodu = Double.Parse(xdoc.SelectSingleNode("//klienti-data/klient/pocetChodu").InnerText);
                                sportTydne = Double.Parse(xdoc.SelectSingleNode("//klienti-data/klient/sportTydne").InnerText);
                                delkaSportu = Double.Parse(xdoc.SelectSingleNode("//klienti-data/klient/delkaSportu").InnerText);
                                overeni = true;
                                
                            }
                            catch
                            {
                                Console.WriteLine("Uživatel zadal v dotazníku neplatnou hodnotu.");
                            }
                            jmeno = xdoc.SelectSingleNode("//klienti-data/klient/jmeno").InnerText;
                            pohlavi = xdoc.SelectSingleNode("//klienti-data/klient/pohlavi").InnerText;
                            zamestnani = xdoc.SelectSingleNode("//klienti-data/klient/zamestnani").InnerText;
                            stres = xdoc.SelectSingleNode("//klienti-data/klient/stres").InnerText;
                            druhSportu = xdoc.SelectSingleNode("//klienti-data/klient/druhSportu").InnerText;
                            ucelDiety = xdoc.SelectSingleNode("//klienti-data/klient/ucelDiety").InnerText;

                            Console.WriteLine("Byl zapsán klient {0} s účelem jídelníčku: {1}", jmeno, ucelDiety);
                            NavratDoMenu();
                    }
                    catch
                    {
                      Console.WriteLine("Zadali jste nesprávnou cestu");
                      NavratDoMenu();
                    }
                    break;
                case '2':
                        if (overeni == false)
                        {
                            spatnaHodnota();
                            NavratDoMenu();
                        }
                        else
                        {
                            if (jmeno == "neznámé")
                            {
                                Console.WriteLine("Žádná data nebyla zadána, prosím načtěte nového klienta.");
                            }
                            else
                            {
                                Console.WriteLine("Základní bazální metabolismus klienta je {0} kcal.", Math.Round(bazalniMetabolismus));
                            }
                            NavratDoMenu();
                        }
                    break;
                case '3':
                        if (overeni == false)
                        {
                            spatnaHodnota();
                            NavratDoMenu();
                        }
                        else
                        {
                            if (jmeno == "neznámé")
                            {
                                Console.WriteLine("Žádná data nebyla zadána, prosím načtěte nového klienta.");
                            }
                            else
                            {
                                if (sportTydne > 0)
                                {
                                    Console.WriteLine("Ideální kalorický příjem v nesportovní den činí {0}kcal a ve sportovní den {1}kcal.", Math.Round(kcalNesportovniDen), Math.Round(kcalSportovniDen));
                                }
                                else
                                {
                                    Console.WriteLine("Ideální kalorický příjem činí {0}", Math.Round(kcalNesportovniDen));
                                }
                            }
                            NavratDoMenu();
                        }
                    break;
                case '4':
                        if (overeni == false)
                        {
                            spatnaHodnota();
                            NavratDoMenu();
                        }
                        else
                        {
                            if (jmeno == "neznámé")
                            {
                                Console.WriteLine("Žádná data nebyla zadána, prosím načtěte nového klienta.");
                            }
                            else
                            {
                                if (sportTydne > 0)
                                {
                                    Console.WriteLine("Denní potřeba živin klienta v nesportovní den činí \n {0} g sacharidů \n {1} g bílkovin \n {2} g tuků \n", Math.Round(sacharidyg), Math.Round(bilkovinyg), Math.Round(tukyg));
                                    Console.WriteLine("Denní potřeba živin klienta ve sportovní den je \n {0} g sacharidů \n {1} g bílkovin \n {2} g tuků", Math.Round(sacharidygS), Math.Round(bilkovinygS), Math.Round(tukygS));
                                }
                                else
                                {
                                    Console.WriteLine("Denní potřeba živin klienta činí \n {0} g sacharidů \n {1} g bílkovin \n {2} g tuků", Math.Round(sacharidyg), Math.Round(bilkovinyg), Math.Round(tukyg));
                                }
                            }
                            NavratDoMenu();
                        }
                        break;
                case '5':
                        if (overeni == false)
                        {
                            spatnaHodnota();
                            NavratDoMenu();
                        }
                        else
                        {
                            if (jmeno == "neznámé")
                            {
                                Console.WriteLine("Žádná data nebyla zadána, prosím načtěte nového klienta.");
                            }
                            else
                            {
                                if (sportTydne > 0)
                                {
                                    if (pocetChodu == 2)
                                    {
                                        Console.WriteLine("Denní rozložení do {0} chodů v nesportovní den lze ideálně rozdělit na 1.chod o velikosti {1}kcal a 2.chodu o velikosti {1}kcal\n", pocetChodu, Math.Round(chod));
                                        Console.WriteLine("Denní rozložení do {0} chodů ve sportovní den lze ideálně rozdělit na 1.chod o velikosti {1}kcal a 2.chodu o velikosti {1}kcal", pocetChodu, Math.Round(chodS));
                                    }
                                    else if (pocetChodu == 3)
                                    {
                                        Console.WriteLine("Denní rozložení do {0} chodů v nesportovní den lze ideálně rozdělit na\nsnídani o velikosti {1}kcal\noběd o velikosti {2}kcal\nvečeři o velikosti {3}kcal\n", pocetChodu, Math.Round(snidane), Math.Round(obed), Math.Round(vecere));
                                        Console.WriteLine("Denní rozložení do {0} chodů ve sportovní den lze ideálně rozdělit na\nsnídani o velikosti {1}kcal\noběd o velikosti {2}kcal\nvečeři o velikosti {3}kcal", pocetChodu, Math.Round(snidaneS), Math.Round(obedS), Math.Round(vecereS));
                                    }
                                    else if (pocetChodu == 4)
                                    {
                                        Console.WriteLine("Denní rozložení do {0} chodů v nesportovní den lze ideálně rozdělit na\nsnídani o velikosti {1}kcal\noběd o velikosti {2}kcal\nsvacinu o velikosti {3}\nvečeři o velikosti {4}kcal\n", pocetChodu, Math.Round(snidane), Math.Round(obed), Math.Round(svacina), Math.Round(vecere));
                                        Console.WriteLine("Denní rozložení do {0} chodů ve sportovní den lze ideálně rozdělit na\nsnídani o velikosti {1}kcal\noběd o velikosti {2}kcal\nsvacinu o velikosti {3}\nvečeři o velikosti {4}kcal", pocetChodu, Math.Round(snidaneS), Math.Round(obedS), Math.Round(svacinaS), Math.Round(vecereS));
                                    }
                                    else if (pocetChodu == 5)
                                    {
                                        Console.WriteLine("Denní rozložení do {0} chodů v nesportovní den lze ideálně rozdělit na\nsnídani o velikosti {1}kcal\n1.svačinu o velikosti {}kcal \noběd o velikosti {2}kcal\n2.svačinu o velikosti {3}\nvečeři o velikosti {4}kcal\n", pocetChodu, Math.Round(snidane), Math.Round(svacina), Math.Round(obed), Math.Round(svacina), Math.Round(vecere));
                                        Console.WriteLine("Denní rozložení do {0} chodů ve sportovní den lze ideálně rozdělit na\nsnídani o velikosti {1}kcal\n1.svačinu o velikosti {}kcal \noběd o velikosti {2}kcal\n2.svačinu o velikosti {3}\nvečeři o velikosti {4}kcal", pocetChodu, Math.Round(snidaneS), Math.Round(svacinaS), Math.Round(obedS), Math.Round(svacinaS), Math.Round(vecereS));
                                    }
                                }
                                else
                                {
                                    if (pocetChodu == 2)
                                    {
                                        Console.WriteLine("Denní rozložení do {0} chodů v nesportovní den lze ideálně rozdělit na 1.chod o velikosti {1}kcal a 2.chodu o velikosti {1}kcal", pocetChodu, Math.Round(chod));
                                    }
                                    else if (pocetChodu == 3)
                                    {
                                        Console.WriteLine("Denní rozložení do {0} chodů v nesportovní den lze ideálně rozdělit na\nsnídani o velikosti {1}kcal\noběd o velikosti {2}kcal\nvečeři o velikosti {3}kcal", pocetChodu, Math.Round(snidane), Math.Round(obed), Math.Round(vecere));
                                    }
                                    else if (pocetChodu == 4)
                                    {
                                        Console.WriteLine("Denní rozložení do {0} chodů v nesportovní den lze ideálně rozdělit na\nsnídani o velikosti {1}kcal\noběd o velikosti {2}kcal\nsvacinu o velikosti {3}\nvečeři o velikosti {4}kcal", pocetChodu, Math.Round(snidane), Math.Round(obed), Math.Round(svacina), Math.Round(vecere));
                                    }
                                    else if (pocetChodu == 5)
                                    {
                                        Console.WriteLine("Denní rozložení do {0} chodů v nesportovní den lze ideálně rozdělit na\nsnídani o velikosti {1}kcal\n1.svačinu o velikosti {}kcal \noběd o velikosti {2}kcal\n2.svačinu o velikosti {3}\nvečeři o velikosti {4}kcal", pocetChodu, Math.Round(snidane), (svacina), Math.Round(obed), Math.Round(svacina), Math.Round(vecere));
                                    }
                                }
                            }
                            NavratDoMenu();
                        }
                        break;
                    case '6':
                        if (overeni == false)
                        {
                            spatnaHodnota();
                            NavratDoMenu();
                        }
                        else
                        {

                            using (StreamWriter sw = new StreamWriter(jmeno + ".txt"))
                            {
                                sw.WriteLine(jmeno);
                                sw.WriteLine("věk:{0}", vek.ToString());
                                sw.WriteLine("výška: {0} cm", vyska.ToString());
                                sw.WriteLine("váha: {0} kg", vaha.ToString());
                                sw.WriteLine("Účel jídelníčku: {0}", ucelDiety);
                                sw.Write("\nBazální metabolismus: {0} kcal\n\n", Math.Round(bazalniMetabolismus).ToString());

                                if (sportTydne > 0)
                                {
                                    sw.Write("Ideální příjem kcal v nesportovní den:");
                                    sw.Write(Math.Round(kcalNesportovniDen).ToString());
                                    sw.WriteLine(" kcal");
                                    sw.Write("Ideální příjem kcal ve sportovní den:");
                                    sw.Write(Math.Round(kcalSportovniDen).ToString());
                                    sw.WriteLine(" kcal");
                                    sw.WriteLine("\nPříjem makroživin v nesportovní den:\nSacharidy:{0} g\nBílkoviny:{1} g\nTuky:{2} g", Math.Round(sacharidyg).ToString(), Math.Round(bilkovinyg).ToString(), Math.Round(tukyg).ToString());
                                    sw.WriteLine("\nPříjem makroživin ve sportovní den:\nSacharidy:{0} g\nBílkoviny:{1} g\nTuky:{2} g\n", Math.Round(sacharidygS).ToString(), Math.Round(bilkovinygS).ToString(), Math.Round(tukygS).ToString());
                                    if (pocetChodu == 2)
                                    {
                                        sw.WriteLine("\nDenní rozložení do {0} chodů v nesportovní den lze ideálně rozdělit na 1.chod o velikosti {1} kcal a 2.chodu o velikosti {1} kcal\n", pocetChodu.ToString(), Math.Round(chod).ToString());
                                        sw.WriteLine("Denní rozložení do {0} chodů ve sportovní den lze ideálně rozdělit na 1.chod o velikosti {1} kcal a 2.chodu o velikosti {1} kcal\n", pocetChodu.ToString(), Math.Round(chodS).ToString());
                                    }
                                    else if (pocetChodu == 3)
                                    {
                                        sw.WriteLine("Denní rozložení do {0} chodů v nesportovní den lze ideálně rozdělit na:\nsnídani o velikosti {1} kcal\noběd o velikosti {2} kcal\nvečeři o velikosti {3} kcal\n", pocetChodu.ToString(), Math.Round(snidane).ToString(), Math.Round(obed).ToString(), Math.Round(vecere).ToString());
                                        sw.WriteLine("Denní rozložení do {0} chodů ve sportovní den lze ideálně rozdělit na:\nsnídani o velikosti {1} kcal\noběd o velikosti {2} kcal\nvečeři o velikosti {3} kcal\n", pocetChodu.ToString(), Math.Round(snidaneS).ToString(), Math.Round(obedS).ToString(), Math.Round(vecereS).ToString());
                                    }
                                    else if (pocetChodu == 4)
                                    {
                                        sw.WriteLine("Denní rozložení do {0} chodů v nesportovní den lze ideálně rozdělit na:\nsnídani o velikosti {1} kcal\noběd o velikosti {2} kcal\nsvacinu o velikosti {3} kcal\nvečeři o velikosti {4} kcal\n", pocetChodu.ToString(), Math.Round(snidane).ToString(), Math.Round(obed).ToString(), Math.Round(svacina).ToString(), Math.Round(vecere).ToString());
                                        sw.WriteLine("Denní rozložení do {0} chodů ve sportovní den lze ideálně rozdělit na:\nsnídani o velikosti {1} kcal\noběd o velikosti {2} kcal\nsvacinu o velikosti {3} kcal\nvečeři o velikosti {4} kcal\n", pocetChodu.ToString(), Math.Round(snidaneS).ToString(), Math.Round(obedS).ToString(), Math.Round(svacinaS).ToString(), Math.Round(vecereS).ToString());
                                    }
                                    else if (pocetChodu == 5)
                                    {
                                        sw.WriteLine("Denní rozložení do {0} chodů v nesportovní den lze ideálně rozdělit na:\nsnídani o velikosti {1} kcal\n1.svačinu o velikosti {} kcal \noběd o velikosti {2} kcal\n2.svačinu o velikosti {3} kcal\nvečeři o velikosti {4} kcal\n", pocetChodu.ToString(), Math.Round(snidane).ToString(), Math.Round(svacina).ToString(), Math.Round(obed).ToString(), Math.Round(svacina).ToString(), Math.Round(vecere).ToString());
                                        sw.WriteLine("Denní rozložení do {0} chodů ve sportovní den lze ideálně rozdělit na:\nsnídani o velikosti {1} kcal\n1.svačinu o velikosti {} kcal \noběd o velikosti {2} kcal\n2.svačinu o velikosti {3} kcal\nvečeři o velikosti {4} kcal", pocetChodu.ToString(), Math.Round(snidaneS).ToString(), Math.Round(svacinaS).ToString(), Math.Round(obedS).ToString(), Math.Round(svacinaS).ToString(), Math.Round(vecereS).ToString());
                                    }
                                }
                                else
                                {
                                    sw.Write("Ideální příjem kcal denně:");
                                    sw.Write(Math.Round(kcalNesportovniDen).ToString());
                                    sw.WriteLine(" kcal");
                                    sw.WriteLine("\nPříjem makroživin během dne:\nSacharidy:{0} g\nBílkoviny:{1} g\nTuky:{2} g\n", Math.Round(sacharidyg).ToString(), Math.Round(bilkovinyg).ToString(), Math.Round(tukyg).ToString());
                                    if (pocetChodu == 2)
                                    {
                                        sw.WriteLine("\nDenní rozložení do {0} chodů lze ideálně rozdělit na:\n1.chod o velikosti {1} kcal\n2.chod o velikosti {1} kcal\n", pocetChodu.ToString(), Math.Round(chod).ToString());
                                    }
                                    else if (pocetChodu == 3)
                                    {
                                        sw.WriteLine("Denní rozložení do {0} chodů lze ideálně rozdělit na:\nsnídani o velikosti {1} kcal\noběd o velikosti {2} kcal\nvečeři o velikosti {3} kcal\n", pocetChodu.ToString(), Math.Round(snidane).ToString(), Math.Round(obed).ToString(), Math.Round(vecere).ToString());
                                    }
                                    else if (pocetChodu == 4)
                                    {
                                        sw.WriteLine("Denní rozložení do {0} chodů lze ideálně rozdělit na:\nsnídani o velikosti {1} kcal\noběd o velikosti {2} kcal\nsvacinu o velikosti {3} kcal\nvečeři o velikosti {4} kcal\n", pocetChodu.ToString(), Math.Round(snidane).ToString(), Math.Round(obed).ToString(), Math.Round(svacina).ToString(), Math.Round(vecere).ToString());
                                    }
                                    else if (pocetChodu == 5)
                                    {
                                        sw.WriteLine("Denní rozložení do {0} chodů lze ideálně rozdělit na:\nsnídani o velikosti {1}kcal\n1.svačinu o velikosti {}kcal \noběd o velikosti {2}kcal\n2.svačinu o velikosti {3}\nvečeři o velikosti {4}kcal\n", pocetChodu.ToString(), Math.Round(snidane).ToString(), Math.Round(svacina).ToString(), Math.Round(obed).ToString(), Math.Round(svacina).ToString(), Math.Round(vecere).ToString());
                                    }
                                }

                                sw.Flush();
                            }
                            Console.WriteLine("Data byla uložena do textového souboru {0}.txt", jmeno);
                            NavratDoMenu();
                        }
                        break;
                    case '7':
                        Console.WriteLine("Konec programu, přeji krásný den :)");
                        Console.ReadKey();
                        break;
            }
        } while (menu != '7');

        }
    }
}
