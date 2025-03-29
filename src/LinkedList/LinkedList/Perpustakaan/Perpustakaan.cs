using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList.Perpustakaan
{

    // Kelas Buku
    public class Buku
    {
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public int Tahun { get; set; }

        public Buku(string judul, string penulis, int tahun)
        {
            Judul = judul;
            Penulis = penulis;
            Tahun = tahun;
        }
    }

    public class BukuNode
    {
        public Buku Data { get; set; }
        public BukuNode Next { get; set; }

        public BukuNode(Buku buku)
        {
            Data = buku;
            Next = null;
        }
    }
    public class KoleksiPerpustakaan
    {
        private BukuNode? head;

        public KoleksiPerpustakaan()
        {
            head = null;
        }

        public void TambahBuku(Buku buku)
        {
            BukuNode newNode = new BukuNode(buku);
            newNode.Next = head;
            head = newNode;
        }

        public bool HapusBuku(string judul)
        {
            BukuNode temp = head;
            BukuNode prev = null;

            while (temp != null && temp.Data.Judul != judul)
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp == null)
            {
                return false;
            }

            if (prev == null)
            {
                head = temp.Next;
            }
            else
            {
                prev.Next = temp.Next;
            }
            return true;
        }
        public Buku[] CariBuku(string kataKunci)
        {
            List<Buku> hasil = new List<Buku>();
            BukuNode temp = head;
            while (temp != null)
            {
                if (temp.Data.Judul.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
                    hasil.Add(temp.Data);
                temp = temp.Next;
            }
            return hasil.ToArray();
        }
        public string TampilkanKoleksi()
        {
            List<string> daftarBuku = new List<string>();
            BukuNode temp = head;
            while (temp != null)
            {
                daftarBuku.Add($"\"{temp.Data.Judul}\"; {temp.Data.Penulis}; {temp.Data.Tahun}");
                temp = temp.Next;
            }
            return string.Join("\n", daftarBuku);
        }
    }
}

