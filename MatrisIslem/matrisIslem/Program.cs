namespace matrisIslem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Matris kaça kaç olsun: ");
            int matrisBüyüklüğü = int.Parse(Console.ReadLine());

            int[,] matris = new int[matrisBüyüklüğü, matrisBüyüklüğü];


            Random random = new Random();

            for (int i = 0; i < matrisBüyüklüğü; i++)
            {
                for (int j = 0; j < matrisBüyüklüğü; j++)
                {
                    matris[i, j] = random.Next(1, 6);
                }
            }
            Console.WriteLine("******\nRandomla alınan matris: ");

            for(int i = 0; i < matrisBüyüklüğü; i++)
            {
                for(int j = 0; j < matrisBüyüklüğü; j++)
                {
                    Console.Write($"{matris[i, j]} ");
                }
                Console.WriteLine();
            }

            int[,] faktoriyelMatris = new int[matrisBüyüklüğü, matrisBüyüklüğü];

            for (int k = 0; k < matrisBüyüklüğü; k++)
            {
                for (int m = 0; m < matrisBüyüklüğü; m++)
                {
                    faktoriyelMatris[k, m] = FaktoriyelBul(matris[k, m]);
                }
            }
            int enKucukDiyagonal = KarakteristikDiyagonalEnKucuk(faktoriyelMatris);

            Console.WriteLine("******\nFaktöriyel alınmış yeni matris: ");
            
            for(int i = 0; i < faktoriyelMatris.GetLength(0); i++)
            {
                for(int j = 0; j < faktoriyelMatris.GetLength(0); j++)
                {
                    Console.Write($"{faktoriyelMatris[i, j]} ");
                }
                Console.WriteLine();
            }


                Console.WriteLine($"******\nEn küçük karakteristik diyagonal eleman: {enKucukDiyagonal}\n****** ");
            
            int diyagonalSonuc = EnKucukDiyagonalFarki(faktoriyelMatris, enKucukDiyagonal);

            Console.WriteLine($"İşlemlerin sonucunda en küçük diyagonalden çıkarılan tüm elemanların mutlaklarının toplamı: {diyagonalSonuc}");

        }

        static int FaktoriyelBul(int number)
        {
            int faktoriyel = 1;
            for (int i = 1; i <= number; i++)
            {
                faktoriyel *= i;
            }
            return faktoriyel;
        }

        static int KarakteristikDiyagonalEnKucuk(int[,] matris)
        {
            int enKucuk = matris[0, 0];

            for (int i = 0; i < matris.GetLength(0); i++)
            {
                if (matris[i, i] < enKucuk)
                {
                    enKucuk = matris[i, i];
                }
            }
            return enKucuk;
        }

        static int EnKucukDiyagonalFarki(int[,] matris, int EnKucukDiyagonal)
        {
            int toplam = 0;

            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for(int j = 0; j < matris.GetLength(0); j++)
                {
                    toplam += Math.Abs(matris[i, j] - EnKucukDiyagonal);
                }
            }
            return toplam;
        }
    }
}
