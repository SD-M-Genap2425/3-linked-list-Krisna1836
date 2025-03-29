using LinkedList.Inventori;
using LinkedList.ManajemenKaryawan;
using LinkedList.Perpustakaan;

namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {
        // Soal Perpustakaan
        KoleksiPerpustakaan newkoleksi = new KoleksiPerpustakaan();

        newkoleksi.TambahBuku(new Buku("Koala Kumal", "Raditya", 2017));
        newkoleksi.TambahBuku(new Buku("Kambing Jantan", "Raditya", 2015));
        newkoleksi.TambahBuku(new Buku("Hangout", "Raditya", 2018));

        Console.WriteLine("---Buku Perpustakaan---");
        newkoleksi.TampilkanKoleksi();
        Console.WriteLine();

        Console.WriteLine("Buku yang dicari: ");
        var cariBuku = newkoleksi.CariBuku("Hangout");
        foreach(var cB in cariBuku)
        {
            Console.WriteLine($"{cB.Judul}; {cB.Penulis}; {cB.Tahun}");
        }
        Console.WriteLine();

        bool Bukudihapus = newkoleksi.HapusBuku("Koala Kumal");
        Console.WriteLine(Bukudihapus ? "Daftar buku setelah dihapus:" : "Tidak ditemukan");
        newkoleksi.TampilkanKoleksi();
        Console.WriteLine();

        // Soal ManajemenKaryawan
        DaftarKaryawan daftarkaryawan = new DaftarKaryawan();

        daftarkaryawan.TambahKaryawan(new Karyawan("001", "John", "Manager"));
        daftarkaryawan.TambahKaryawan(new Karyawan("002", "Smith", "HR"));
        daftarkaryawan.TambahKaryawan(new Karyawan("003", "Muller", "Training"));

        Console.WriteLine("---Daftar Karyawan---");
        daftarkaryawan.TampilkanDaftar();
        Console.WriteLine();

        Console.WriteLine("Karyawan yang dicari:");
        var cariKaryawan = daftarkaryawan.CariKaryawan("Muller");
        foreach( var cK in cariKaryawan)
        {
            Console.WriteLine($"{cK.NomorKaryawan}; {cK.Nama}; {cK.Posisi}");
        }
        Console.WriteLine();

        bool berhasilHapus = daftarkaryawan.HapusKaryawan("001");
        Console.WriteLine(berhasilHapus ? "Daftar karyawan setelah dihapus:" : "Tidak ditemukan:");
        daftarkaryawan.TampilkanDaftar();
        Console.WriteLine();

        // Soal Inventori
        ManajemenInventori MK = new ManajemenInventori();

        Console.WriteLine("---Daftar Item---");
        MK.TambahItem(new Item("Apple", 60));
        MK.TambahItem(new Item("Banana", 67));
        MK.TambahItem(new Item("Orange", 56));
        MK.TampilkanInventori();
        Console.WriteLine();

        bool berhasil = MK.HapusItem("Banana");
        Console.WriteLine(berhasil ? "Setelah Item Dihapus" : "Tidak ditemukan");
        MK.TampilkanInventori();
    }
}
