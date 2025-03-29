using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList.Perpustakaan;

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
    public Buku Buku { get; set; }
    public BukuNode Next { get; set; }

    public BukuNode(Buku buku)
    {
        Buku = buku;
        Next = null;
    }
}
    public class KoleksiPerpustakaan
    {
        private BukuNode head;
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

            while (temp != null && temp.Buku.Judul != judul)
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp == null) return false;

            if (prev == null)
                head = temp.Next;
            else
                prev.Next = temp.Next;

            return true;
        }
        public Buku[] CariBuku(string kataKunci)
        {
            List<Buku> hasil = new List<Buku>();
            BukuNode temp = head;
            while (temp != null)
            {
                if (temp.Buku.Judul.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
                    hasil.Add(temp.Buku);
                temp = temp.Next;
            }
            return hasil.ToArray();
        }
        public void TampilkanKoleksi()
        {
            BukuNode temp = head;
            while (temp != null)
            {
                Console.WriteLine($"{temp.Buku.Judul}; {temp.Buku.Penulis}; {temp.Buku.Tahun}");
                temp = temp.Next;
            }
        }
    }

