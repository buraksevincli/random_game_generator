using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using game_generator;                           //generator olarak kullandığımız namespace'i buradan çağırıyoruz.

//Bu projede Random Fonksiyonu ile obje oluşturarak sayı seçtirme, obje tanımlama, namespace-class-fonksiyon oluşturma ve main fonksiyonuna
//gerek static, gerek obje oluşturarak çağırma, verbatim çalıştırma, for döngüsü, if-else yapısı, switch-case yapısı, foreach döngüsü,
//boolean değişkeni, dizi oluşturma, diziden değer çekme ve diziye değer toplama pratikleri yapıldı.

namespace random_game_generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int themeNo, placeNo, gamerNo, gameArtist, dimensionNo;  //gameGenerator sınıfından çağırılacak fonksiyonlara gönderilecek değerler.
            Random generator = new Random();                         //Rastgele değer atamak için Random fonksiyonundan oluşturulan obje.
            dimension dim= new dimension();                          //dimension sınıfından fonksiyon kullanmak için oluşturulan obje.
            themeNo = generator.Next(1,6);                           //Random oluşturulan değerler..
            placeNo = generator.Next(1,6);                           
            gamerNo = generator.Next(1,3);                           
            gameArtist= generator.Next(1,6);                         
            dimensionNo= generator.Next(2,4);                        
            string[] random_game = {gameGenerator.theme(themeNo), gameGenerator.place(placeNo), gameGenerator.gamer(gamerNo), gameGenerator.artist(gameArtist), dim.gameDimension(dimensionNo)};  //Tüm fonksiyonlardan gelen değerler bir diziye toplandı.
            foreach (string game_info in random_game)                             //Dizinin tüm elemanlarını tek tek yazdırmak için 
            {                                                                     //foreach döngüsü kullanıldı.
                Console.Write(@game_info+" - ");                                  
            }

            Console.WriteLine("\nOyunun Teması: "+game_generator.gameGenerator.theme(themeNo));              //Ayrıca fonksiyonlardan gelen
            Console.WriteLine("Oyunun Geçeceği Yer: "+game_generator.gameGenerator.place(placeNo));          //tüm değerler açıklamalarıyla
            Console.WriteLine("Oyuncu Sayısı: "+game_generator.gameGenerator.gamer(gamerNo));                //tek tek yazıldı.
            Console.WriteLine("Başrol Oyuncumuz: " +game_generator.gameGenerator.artist(gameArtist));        
            Console.WriteLine("Oyun Görselleri: "+dim.gameDimension(dimensionNo));                           
            Console.ReadLine();
        }

    }
    public class dimension                      //Bu sınıfı static olmayan bir fonksiyon tanımladığım için ayrık tuttum.
    {
        public string a = "";
        public string gameDimension(int x)
        {
            for (int i=0; i<4; i++)             //for döngüsünü sırf pratik için ekledim ne yapmış bu burda demeyin :)
            {
                if (x == 2)
                {
                    a = "2 Boyutlu";
                }
                else
                {
                    a = "3 Boyutlu";
                }
            }
            return a;
        }
    }
}
namespace game_generator                    //oyun için random tema,mekan,oyuncu sayısı ve baş rol seçim namespace'i
{
    public class gameGenerator
    {
        public static string theme(int x)              //main fonksiyonundan random sayı alıp switch-case yapısına sokarak
        {                                              //seçim yaptırıldı ve maine değer döndürüldü
            string gameTheme = "" ;                    

            switch (x)
            {
                case 1: gameTheme = "Korku";
                    break;
                case 2: gameTheme = "Aksiyon";
                    break;
                case 3: gameTheme = "Gerilim";
                    break;
                case 4: gameTheme = "Bulmaca";
                    break;
                case 5: gameTheme = "Strateji";
                    break;
                default:
                    break;
            }
            return gameTheme;
        }
        public static string place(int x)           //bu fonksiyonda if-else yapısı ile mekan seçimi döndürüldü.
        {
            string gamePlace = "";

            if (x == 1)
            {
                gamePlace = "Akıl Hastanesi";
            }
            if (x == 2)
            {
                gamePlace = "Üniversite";
            }
            if (x == 3)
            {
                gamePlace = "Açık Dünya";
            }
            if (x == 4)
            {
                gamePlace = "Hastane";
            }
            else
            {
                gamePlace = "Şato";
            }
            return gamePlace;
        }
        public static string gamer(int x)           //bu fonksiyonda if-else ve boolean birleştirilerek seçim yapıldı.
        {
            string gamerNo = "";
            bool gamer = true;
            if (x == 1)
            {
                gamer = false;
            }
            else
            {
                gamer = true;
            }
            if (gamer == true)
            {
                gamerNo = "Çok Oyunculu";
            }
            else
            {
                gamerNo = "Tek Oyunculu";
            }
            return gamerNo;
        }
        public static string artist(int x)         //bu fonksiyonda gelen random değer dizi elemanı indisi olarak tanımlandı.
        {                                          //geriye dizi elemanı döndürüldü.
            string[] artists = { "Burak", "Caner", "Onur", "Elif", "Rabia" };
            return artists[x - 1];
        }
    }
}
