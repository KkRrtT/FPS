using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpojeniZadatci : MonoBehaviour
{
    /*
     * SUMMARY
     * 
     * Redanje i ispisivanje brojeva u Arrayu(a)
     * 
     */    
    private void Sort(int[] a)//Sortira od najnizeg zatim ispisuje
    {
        Array.Sort(a);
        foreach (int i in a)
        {
            print(i);
        }
    }
    private void SortDva(int[] a)//Sortira od najnizeg ali ispisuje od najviseg
    {
        Array.Sort(a);
        for (int i = a.Length - 1; i >= 0; i--)
        {
            print(a[i]);
        }
    }

    private void SortTri(int[] a)//Sortira od najviseg zatim ispisuje
    {
        Array.Sort(a, (a, b) => b.CompareTo(a));
        foreach (int i in a)
        {
            print(i);
        }
    }

    private void SortCetiri(int[] a)//Sortira od najviseg zatim ispisuje prvoga
    {
        Array.Sort(a, (a, b) => b.CompareTo(a));
        print(a[0]);
    }


    /*
     * SUMMARY
     * 
     * Provjerava parnost nekog broja
     * 
     */
    private bool Parni(int a)//provjerava dali je zadani broj(a) paran ili neparan i vraca (true) ili (false)
    {
        if (a % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    /*
     * SUMMARY
     * 
     * Ispisuje brojeve iz arraya(a) koji su veci od zadane varijable(b) inkluzivno
     * 
     */
    private void VeciOd(int[] a, int b)//ispisuje elemente iz arraya a koji su veci od varijable b
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] >= b)
            {
                print(a[i]);
            }
        }
    }


    /*
     * SUMMARY
     * 
     * Dodaje sve elemente iz liste(b) listi(a) uz mogucnost sortiranjeg od najmanjeg do najveceg o obratno
     * 
     */
    private void Liste(List<int> a, List<int> b, bool c, bool d)//dodaje listu b u listu a i cleara listu b
    {
        for (int i = 0; i < b.Count; i++)
        {
            a.Add(b[i]);
        }

        if (c)//sortira od najmanjeg
        {
            a.Sort();
        }
        if (d)//okrece poredak u listi nakon sorta
        {
            a.Reverse();
        }

        b.Clear();
    }


    /*
     * SUMMARY
     * 
     * zbraja sve brojeve u listi(a) i sprema rezultat u varijablu(b)
     * 
     */
    private void Suma(List<int> a, ref int b)
    {
        b = a.Sum();
    }


    /*
     * SUMMARY
     * 
     * provjerava dali je broj prost i vraca (true) ili (false)
     * 
     */
    private bool ProvjeraProstogBroja(int a)
    {
        if (a == 1)//brojevi jednaki ili manji broju jedan automatski nisu prosti
        {
            return false;
        }

        int sqrR = (int)Mathf.Sqrt(a); //ako je broj nije prost automatski ima djelitelja koji je manji ili jednak njegovom korjenu cause math gibberish
        for (int i = 2; i <= sqrR; i++)
        {
            if (a % i == 0)
            {
                return false;
            }
        }

        return true;//ako nijedna od ove dvije provjere ne vrati false znaci da je broj prost i vraca se true
    }

    /*
     * SUMMARY
     * 
     * //ispisuje sve parne brojeve u rasponu od (a(inkluzivno)) i (b(ekskluzivno))
     * 
     */
    private void IspisParnihURasponu(int a, int b)//ispisuje sve parne brojeve izmedu a i b, ekskluzivno
    {
        for (int i = a; i < b; i++)
        {
            if (i % 2 == 0)
            {
                print(i);
            }
        }
    }
}
