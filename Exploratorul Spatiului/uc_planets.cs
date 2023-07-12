﻿using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exploratorul_Spatiului
{
    public partial class uc_planets : UserControl
    {
        public uc_planets()
        {
            InitializeComponent();
        }
        
        void change_image()
        {
            
            
        }
        private void uc_map_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.StartIndex = 0;
            change_image();
        }

        string[] descriere1 =
        {
            "Forma este aproximativ sferoidală oblică și, datorită rotației, Pământul este aplatizat la poli și bombat în jurul ecuatorului. Diametrul său la ecuator este de 43 de kilometri, mai mare decât diametrul pol-pol. Principalele deviații de pe suprafața Pământului sunt: Muntele Everest, 8.850 de metri deasupra nivelului mării și Groapa Marianelor, 10.924 de metri sub nivelul mării.Masa Pământului se compune în principal din fier (32,1 %), oxigen (30,1 %), siliciu (15,1 %), magneziu (13,9 %), sulf (2,9 %), nichel (1,8 %), calciu 1,5 %), aluminiu (1,4 %), restul de 1,2 % constând din cantități mici de alte elemente. Datorită segregării masei se estimează că nucleul se compune în principal din fier (88,8 %), cu cantități mai mici de nichel (5,8 %), sulf (4,5 %) și mai puțin de 1 % oligoelemente. Suprafața totală a Pământului este de aproximativ 510 milioane de kilometri pătrați, dintre care 70,8%, respectiv 361,13 kilometri pătrați sunt sub nivelul mării și acoperiți cu ocean, restul de 29,2 , respectiv 148,94 milioane de kilometri pătrați este neacoperit de apă și constă în munți, câmpii, deșerturi, platouri și alte forme de relief.",
            "1. Mercur este cea mai mică planetă din Sistemul Solar. Are diametrul de doar 4.878 kilometri, ceea ce înseamnă că are dimensiunea a două cincimi din cea a Pământului. Și, din câte s-au descoperit până acum, planeta se află într-un proces de micșorare. Un studiu din 2014 a relevat că, de la formarea sa, în urmă cu aproximativ 4.5 miliarde de ani, Mercur s-a tot contractat." +Environment.NewLine+"2. Una dintre cele mai interesante curiozități despre planeta Mercur are legătură cu timpul: un an pe această planetă durează doar 88 de zile pământești. Dar, din cauza vitezei de rotație mici, o zi pe Mercur durează de două ori mai mult, 176 de zile pământești."+Environment.NewLine+"3. Chiar dacă este mică, această planetă este foarte densă. Dintre planetele din Sistemul Solar, doar Pământul are o densitate mai mare.",
            "1. Venus este a doua planeta de la Soare (108 milioane de km distanta) si al doilea cel mai luminos corp ceresc din timpul noptii, dupa Luna;" + Environment.NewLine + "2. Aceasta planeta a fost denumita dupa zeita romana a dragostei si frumusetii, Venus;" + Environment.NewLine + "3. O zi pe Venus dureaza mai mult decat un an; miscarea de revolutie in jurul Soarelui dureaza 225 de zile, in timp ce o rotatie completa pe orbita proprie dureaza 243 de zile;" + Environment.NewLine + "4. Atmosfera lui Venus este formata din dioxid de carbon (96.5%) si azot (3.5%); exista trei straturi de nori care provoaca ploi de acid sulfuric;",
            "1. Marte este a patra planeta de la Soare; este denumita si Planeta Rosiei datorita solurilor sale rosiatice, bogate in oxid de fier;"+Environment.NewLine+"2. Este cea mai departata planeta telurica fata de Soare, distanta media fata de acesta fiind de 240 de miloane de km;"+Environment.NewLine+"3. Marte are aproximativ 10% din greutatea Pamantului si o circumferinta ecuatoriala de 21.344 km, aproximativ 53% din cea a Pamantului (40.075 km);"+Environment.NewLine+" 4. Marte are doi sateliti naturali, Phobos si Deimos; acestia sunt blocuri stancoase de forma neregulata, cel mai probabil fiind asteroizi; "+Environment.NewLine+" 5. Marte executa o rotatie completa pe orbita proprie intr-un timp asemanator Pamantului, 24.6 ore, insa o rotatie completa in jurul soarelui (un an) dureaza 687 de zile;",
            "1. Jupiter este cea mai mare planeta din Sistemul Solar;"+Environment.NewLine+"2. Jupiter este de 318 ori mai mare decat Pamantul si are un volum de 1,321 de ori mai mare; desi este gigant in comparatie cu Pamantul, Jupiter are doar o cincime din densitatea acestuia datorita compozitiei;"+Environment.NewLine+"3. Jupiter este o planeta gazoasa, fiind compusa din hidrogen (90%) si heliu(10%), asemanandu-se din acest punct de vedere cu o stea in miniatura;"+Environment.NewLine+" 4. Oamenii de stiinta cred ca Jupiter are un nucleu format din hidrogen metalic acoperit de un strat de hidrogen molecular, insa nimic concret nu s-a descoperit pana in prezent; se estimeaza ca temperatura nucleului este de aproximativ 35.300 grade Kelvin (~30.000 grade Celsius), de 7 ori mai fierbinte decat suprafata Soarelui;"+Environment.NewLine+"5. Jupiter are o raza medie de aproape 70.000 km, cam o zecime din cea a Soarelui, si un diametru ecuatorial de 142.984 km, de 11.2 mai mare decat cel al Pamantului;",
            "1. Saturn este a sasea planeta de la Soare si a doua cea mai mare din Sistemul Solar, dupa Jupiter;"+Environment.NewLine+"2. La fel ca Jupiter, Uranus si Neptun, Saturn este o planeta gazoasa; aceasta este compusa in mare parte din hidrogen (96%) si mici proportii de heliu (3%) si alte elemente;"+Environment.NewLine+"3. Saturn este de aproximativ 95 de ori mai mare decat Pamantul si are un volum de 763 de ori mai mare;"+Environment.NewLine+" 4. Saturn este cea mai mica densitate dintre toate planetele Sistemului Solar, fiind singura mai putin densa decat apa;"+Environment.NewLine+"5. Distanta medie intre Saturn si Soare este de 1.426 milioane km;"+Environment.NewLine+"6. O zi dureaza doar 10.7 ore, iar un pe Saturn dureaza 29.4 ani terestri;",
            "1. Uranus este a saptea planeta de la Soare si a treia cea mai mare din Sistemul Solar, dupa Jupiter si Saturn;"+Environment.NewLine+"2. Un aspect unic in legatura cu Uranus este axa sa, care nu este perpedinculara pe planul eliptic, ci aproape paralel cu acesta; cand sonda spatiala Voyager 2 a trecut pe langa aceasta, polul sud a lui Uranus era orientat spre Soare;"+Environment.NewLine+"3. Uranus este prima planeta descoperita in vremurile moderne, observata de astronomul William Herschel pe 13 martie 1781; acesta a crezut initial ca Uranus este o cometa; "+Environment.NewLine+"4. Uranus a fost numita dupa zeul grec al cerurilor;"+Environment.NewLine+"5. Distanta media intre Uranus si Soare este de 2.9 miliarde de km, fiind de 19 ori mai departe de Soare decat Pamantul;"+Environment.NewLine+"6. Desi are un diametru mai mare decat Neptun (Uranus – 51.000 km, Neptun – 49.500 km), Uranus are o masa mai mica decat acesta; este de 14.5 ori mai greu decat Pamantul",
            "1. Neptun este a opta si cea mai indepartata planeta de Soare; este a patra cea mai mare planeta din Sistemul Solar si este de 17 ori mai mare decat Pamantul;"+Environment.NewLine+"2. Distanta medie de la Neptun la Soare este de 4.503.443.661 km, fiind de aproximativ 30 de ori mai departe decat Pamantul;"+Environment.NewLine+"3. Neptun are un diametru ecuatorial de 48.528 si este de 15 ori mai greu decat Pamantul; "+Environment.NewLine+"4. Neptun are o compozitie asemanatoare cu vecina sa, Uranus, ~80% hidrogen, ~18% heliu, ~1.5% metan si 0.5% alte elemente;"+Environment.NewLine+"5. O zip e Neptun dureaza doar 16, in schimb un an este echivalentul la 165 de ani terestri;"+Environment.NewLine+"6. La fel ca toate planetele gazoase, Neptun nu are o suprafata solida, ci un nucleu din apa, ammoniac si metan; se estimeaza ca temperature nucleului este de aproximativ 5.000 de grade Celsius;",
        };
        string[] descriere2 =
        {
            "1. Plăcile tectonice mențin planeta stabilă. Pământul este singurul corp ceresc din Sistemul nostru solar cu plăci tectonice. Practic, scoarța exterioară a Terrei este împărțită în regiuni cunoscute sub numele de plăci tectonice. Acestea plutesc deasupra magmei din interiorul Pământului, se mișcă și se pot lovi una de cealaltă. Când două plăci tectonice se ciocnesc, una va trece pe sub cealaltă, iar acolo unde se despart, vor permite formarea unei noi cruste. Acest proces este foarte important din mai multe motive. În primul rând acest lucru duce la refacerea tectonică și la activitate geologică (adică cutremure, erupții vulcanice, construirea de munți și formarea de șanțuri oceanice), dar are și o importanță intrinsecă ciclului carbonului. Când plantele microscopice din ocean mor, ele cad pe fundul oceanului."+Environment.NewLine+"2.Pământul nu se rotește în jurul axei sale în 24 de ore. De fapt, este nevoie de 23 de ore, 56 de minute și 4 secunde pentru ca planeta noastră să se rotească, o dată complet, în jurul axei sale. Acest proces este numit de astronomi „Zi Sidereală”.",
            "4. Dat fiind că are o masă mai mică decât cea a Pământului, forța gravitațională pe Mercur este cu 62% mai mică decât cea de pe Terra. Așadar, o persoană care pe planeta noastră cântărește 45 de kilograme va cântări doar 17 kilograme pe Mercur."+Environment.NewLine+"5. Deoarece Mercur este situată atât de aproape de Soare, temperaturile de aici au variații extreme. În timpul mișcării de rotație, pe partea îndreptată spre Soare temperatura ajunge la 427 de grade Celsius, în timp ce pe cealaltă parte ea scade până la -180 de grade Celsius."+Environment.NewLine+"Tot datorită apropierii de Soare, acest astru se vede de trei ori mai mare de pe Marte decât atunci când este văzut de pe Terra." +Environment.NewLine+ "6. Planeta Mercur nu are o atmosferă propriu-zisă, ci un înveliș pe care oamenii de știință numesc „exosferă”. Acest strat gazos subțire este format din atomi aruncați de pe suprafață de vânturile solare. Exosfera este compusă în principal din oxigen, sodiu, hidrogen, heliu și potasiu.",
            "5. Venus este cea mai fierbinte planeta din Sistemul Solar, cu temperaturi ce ajung pana la 480 de grade Celsius;" + Environment.NewLine + "6. Pana in prezent Venus a fost explorata de peste 40 de nave spatiale; la inceputul anilor ’90, sonda spatiala Magellan a cartografiat 98% din suprafata planetei; este cea mai explorata planeta din Sistemul Solar, exceptand Pamantul;" + Environment.NewLine + "7. Venus este singura planeta din Sistemul Solar care se roteste in sensul acelor de ceasornic;" + Environment.NewLine + " 8. Venus nu are nici un satelit natural;",
            "6. Fiind mai departe de Soare decat Pamantul, temperaturile pe Marte sunt mai scazute; acestea se incadreaza intre -153 de grade, la poli, si 20 de grade, la ecuator;" + Environment.NewLine + "7. Pentru ca are o inclinatie axiala foarte apropiata de cea a Pamantului (25.19 Marte, 26.27 Pamant), Marte are anotimpuri, la fel ca planeta noastra;" + Environment.NewLine + "8. Atmosfera martiana este foarte subtire si este formata in mare parte din dioxid de carbon (96%);" + Environment.NewLine + "9. Pe Marte se afla cel mai inalt munte din Sistemul Solar, Olympus Mons, cu o altitudine de 26.000 m si o suprafata asemanatoare cu cea a Germaniei;" + Environment.NewLine + " 10. Aici se gaseste si cel mai mare canion din Sistemul Solar, Valles Marineris; acesta are o lungime de aproximativ 4.000 de km si o adancime maxima de 7 km;",
            "6. O zi pe Jupiter dureaza doar 9.9 ore, iar un an dureaza 4.334 de zile, adica aproape 12 ani;"+Environment.NewLine+"7. Distanta medie de la Jupiter la Soare este de 778.547.199 km;"+Environment.NewLine+"8. Datorita distantei foarte mari fata de Soare, caldura primita de la acesta este aproape neglijabila, Jupiter incalzindu-se practic singura, emanand caldura din interior prin convectia dintre hidrogenul aflat in stare lichida si cel in stare de plasma;"+Environment.NewLine+"9. Desi ca si compozitie Jupiter se asemana cu o stea, nu are destula energie pentru a incepe fuziunea hidrogenului cu heliul, procesul care alimenteaza o stea; pentru a putea fi considerata o stea “cu acte in regula”, Jupiter ar fi trebuit sa fie de 75-80 de ori mai mare; unii astronomi cred ca Jupiter chiar este o stea “esuata”; altii cred ca Jupiter se va “aprinde” intr-o buna zi, distrugand Pamantul;"+Environment.NewLine+"10. Temperatura medie la suprafata lui Jupiter este de -145 de grade Celsius;",
            "7. Cel mai cunoscut aspect al lui Saturn este sistemul sau de inele; la inceputul anilor ’80, sondele Voyager au descoperit ca inelele planetare ale lui Saturn sunt alcatuite din particule de gheata, roca si praf, ce variaza ca marime de la cativa microni la cativa metri;"+Environment.NewLine+"8. Sistemul de inele se intinde la sute de mii de km distanta fata de Saturn, insa au o grosime medie de doar 10 metri; sonda Cassini-Huygens a descoperit insa anumite formatiuni din inele care ajung la 3 km grosime;"+Environment.NewLine+"9. Inelele sunt denumite alfabetic, in ordinea descoperirii lor, A, B, C, D, E, F si G; acestea sunt relativ aproapiata intre ele, cu exceptia Diviziunii Cassini, un gol de aproximativ 4.700 km intre inelele B si A;"+Environment.NewLine+" 10. Inelul D a fost descoperit in 2009 si este cel mai subtire si cel mai apropiat de Saturn; in interiorul sau ar incapea un miliard de Pamanturi;",
            "7. O zi pe Uranus dureaza 17 ore, iar o rotatie completa in jurul Soarelui (un an) are loc in 84 de ani;"+Environment.NewLine+"8. Atmosfera lui Uranus este formata din hidrogen (83%), heliu (15%), metan (2.3%) si alte elemente;"+Environment.NewLine+"9. Uranus are 27 de sateliti naturali, numite dupa personaje din opera lui William Shakespeare (Cordelia, Ofelia, Bianca, Cressida, Desdemonda, Julieta, Ariel, Oberon etc;) "+Environment.NewLine+"10. Cei mai mari sateliti ai lui Uranus sunt Oberon si Titania;"+Environment.NewLine+"11. La fel ca Jupiter si Saturn, Uranus este inconjurat de inele, 13 la numar; acestea au grosimi cuprinse intre 0.1 si 15 km si latimi de 1-17.000 km;"+Environment.NewLine+"12. Temperatura medie pe Uranus este de -216 grade Celsius, fiind cea mai rece planeta din Sistemul Solar;"+Environment.NewLine+"13. Singura sonda spatiala care a vizitat Uranus este Voyager 2, care a trecut pe langa aceasta in 1986, la o distanta de 81.500 km;",
            "7. Neptun are 13 sateliti cunoscuti, cel mai mare dintre ei fiind Triton, descoperit la doar 17 zile dupa Neptun;"+Environment.NewLine+"8. Pe Neptun exista o pata mare intunecata, asemanatoare cu Marea Pata Rosie de pe Jupiter, descoperita in 1989 de sonda Voyager 2, lucru ce indica activitati meteorologice in atmosfera lui Neptun;"+Environment.NewLine+"9. Temperatura medie pe Neptun este de -218 grade Celsius, fiind una dintre cele mai reci planete din Sistemul Solar;"+Environment.NewLine+"10. Culoarea albastra a lui Neptun este data de metanul din atmosfera;"+Environment.NewLine+"11. Neptun a fost denumita dupa zeul grecesc al marii, Neptun;"+Environment.NewLine+"12. Neptun primeste 1/900 din caldura Soareleui pe care o primeste Pamantul;"+Environment.NewLine+"13. Neptun are propria sursa de caldura; aceasta emite de 2.7 ori mai multa caldura decat primeste;",
        };

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as Guna2ComboBox;
            guna2PictureBox1.ImageLocation = Application.StartupPath + @"/Data/planet/" + combo.Text.ToString().Trim() + @".png";
            richTextBox1.Text = descriere1[combo.SelectedIndex];
            richTextBox2.Text = descriere2[combo.SelectedIndex];
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}