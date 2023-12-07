using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> stringslist = new List<string>();
            using (StreamReader indata = new StreamReader("TEXT.txt"))
            {
                while (!indata.EndOfStream)
                {
                    stringslist.Add(indata.ReadLine());
                }
            }
            List<string> cards = new List<string>();
            List<int> values = new List<int>();
            List<int> bids = new List<int>();
            for (int i = 0; i < stringslist.Count; i++)
            {
                for (int j = 0; j < stringslist[i].Length; j++)
                {
                    stringslist[i] = stringslist[i].Replace('A', 'z');
                    stringslist[i] = stringslist[i].Replace('K', 'y');
                    stringslist[i] = stringslist[i].Replace('Q', 'x');
                    stringslist[i] = stringslist[i].Replace('J', 'w');
                    stringslist[i] = stringslist[i].Replace('T', 'v');
                }
                int value = 0;
                string a = stringslist[i].Substring(0, 5);
                string e = stringslist[i].Substring(0, 5);
                int match = 0;
                int match2 = 0;
                int match3 = 0;
                int match4 = 0;
                char z = a[0];
                for (int y = 0; y < a.Length; y++)
                {
                    if (a[y] == z)
                    {
                        match++;
                        int t = a.IndexOf(z);
                        a = a.Remove(t, 1);
                        y--;
                    }
                }
                if (a.Length != 0)
                {
                    z = a[0];
                    for (int y = 0; y < a.Length; y++)
                    {
                        if (a[y] == z)
                        {
                            match2++;
                            int t = a.IndexOf(z);
                            a = a.Remove(t, 1);
                            y--;
                        }
                    }
                    if(a.Length != 0)
                    {
                        z = a[0];
                        for (int y = 0; y < a.Length; y++)
                        {
                            if (a[y] == z)
                            {
                                match3++;
                                int t = a.IndexOf(z);
                                a = a.Remove(t, 1);
                                y--;
                            }
                        }
                        if(a.Length == 2)
                        {
                            if (a[0] == a[1])
                            {
                                match4 = 2;
                            }
                        }
                    }
                }
                // if all five
                if(match == 5 || match2 == 5 || match3 == 5) { value = 7; }
                // if four
                else if(match == 4 || match2 == 4 || match3 == 4) { value = 6; }
                // if 2+3
                else if(match + match2 == 5 || match + match3 == 5 || match2 + match3 == 5 || match + match4 == 5) { value = 5; }
                // if 3
                else if(match == 3 || match2 == 3 || match3 == 3) { value = 4; }
                // if 2+2
                else if(match + match2 == 4 || match + match3 == 4 || match2 + match3 == 4 || match + match4 == 4 || match2 + match4 == 4) { value = 3; }
                // if 2
                else if(match == 2 || match2 == 2 || match3 == 2 || match4 == 2) { value = 2; }
                // if 1
                else{ value = 1; }

                int counter = 0;
                // insert at correct place in list
                for (int y = 0; y < values.Count; y++)
                {
                    if (values[y] < value)
                    {
                        counter++;
                    }
                    else if (values[y] == value)
                    {
                        if (cards[y][0] == e[0])
                        {
                            if (cards[y][1] == e[1])
                            {
                                if (cards[y][2] == e[2])
                                {
                                    if (cards[y][3] == e[3])
                                    {
                                        if (cards[y][4] == e[4])
                                        {

                                        }
                                        else if ((int)cards[y][4] > (int)e[4])
                                        {
                                            break;
                                        }
                                        else if ((int)cards[y][4] < (int)e[4])
                                        {
                                            counter++;
                                        }
                                    }
                                    else if ((int)cards[y][3] > (int)e[3])
                                    {
                                        break;
                                    }
                                    else if ((int)cards[y][3] < (int)e[3])
                                    {
                                        counter++;
                                    }
                                }
                                else if ((int)cards[y][2] > (int)e[2])
                                {
                                    break;
                                }
                                else if ((int)cards[y][2] < (int)e[2])
                                {
                                    counter++;
                                }
                            }
                            else if ((int)cards[y][1] > (int)e[1])
                            {
                                break;
                            }
                            else if ((int)cards[y][1] < (int)e[1])
                            {
                                counter++;
                            }
                        }
                        else if ((int)cards[y][0] > (int)e[0])
                        {
                            break;
                        }
                        else if ((int)cards[y][0] < (int)e[0])
                        {
                            counter++;
                        }
                    }
                }
                if (values.Count == 0)
                {
                    values.Add(value);
                    cards.Add(stringslist[i].Substring(0, 5));
                    bids.Add(int.Parse(stringslist[i].Substring(6)));
                }
                else
                {
                    values.Insert(counter, value);
                    cards.Insert(counter, stringslist[i].Substring(0, 5));
                    bids.Insert(counter, int.Parse(stringslist[i].Substring(6)));
                }
            }
            long total = 0;
            for (int i = 0; i < bids.Count; i++)
            {
                total = total + (bids[i] * (i + 1));
            }
            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}
