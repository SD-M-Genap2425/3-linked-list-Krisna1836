using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.ManajemenKaryawan
{
    public class Karyawan
    {
        public string NomorKaryawan { get; set; }
        public string Nama { get; set; }
        public string Posisi { get; set; }

        public Karyawan(string nomor, string nama, string posisi)
        {
            NomorKaryawan = nomor;
            Nama = nama;
            Posisi = posisi;
        }
    }
    public class KaryawanNode
    {
        public Karyawan Karyawan { get; set; }
        public KaryawanNode Next { get; set; }
        public KaryawanNode Prev { get; set; }

        public KaryawanNode(Karyawan karyawan)
        {
            Karyawan = karyawan;
            Next = null;
            Prev = null;
        }
    }

    public class DaftarKaryawan
    {
        private KaryawanNode head, tail;

        public void TambahKaryawan(Karyawan karyawan)
        {
            KaryawanNode newNode = new KaryawanNode(karyawan);
            if (tail == null)
                head = tail = newNode;
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }
        public bool HapusKaryawan(string nomorKaryawan)
        {
            KaryawanNode temp = head;
            while (temp != null && temp.Karyawan.NomorKaryawan != nomorKaryawan)
            {
                temp = temp.Next;
            }

            if (temp == null)
            {
                return false;
            }

            if (temp.Prev != null)
            {
                temp.Prev.Next = temp.Next;
            }
            else
            {
                head = temp.Next;
            }

            if (temp.Next != null)
            {
                temp.Next.Prev = temp.Prev;
            }
            else
            {
                tail = temp.Prev;
            }
            return true;
        }
        public Karyawan[] CariKaryawan(string kataKunci)
        {
            List<Karyawan> hasil = new List<Karyawan>();
            KaryawanNode temp = head;
            while (temp != null)
            {
                if (temp.Karyawan.Nama.Contains(kataKunci, StringComparison.OrdinalIgnoreCase) ||
                    temp.Karyawan.Posisi.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
                    hasil.Add(temp.Karyawan);
                temp = temp.Next;
            }
            return hasil.ToArray();
        }
        public string TampilkanDaftar()
        {
            StringBuilder sb = new StringBuilder();
            KaryawanNode temp = tail;
            while (temp != null)
            {
                sb.AppendLine($"{temp.Karyawan.NomorKaryawan}; {temp.Karyawan.Nama}; {temp.Karyawan.Posisi}");
                temp = temp.Prev;
            }
            return sb.ToString().TrimEnd();
        }
    }
}
