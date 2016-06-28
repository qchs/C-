using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



namespace Lottery
{
    public class Program
    {
        static ArrayList RandomArray(ArrayList array, int num)
        {
            #region 从array里获取num个不重复的数，并存入一个新的数组
            Random rnd = new Random(DateTime.Now.Millisecond);
            ArrayList aLucky = new ArrayList();

            for (int i = 0; i < num; i++)
            {
                int r = rnd.Next(0, array.Count);
                aLucky.Add(array[r]);
                //  Console.Write(al[r] + " ");
                array.Remove(array[r]);
            }

            #endregion
            return aLucky;

        }

        static void Lucky(int totalNum, int perNum, int times, ArrayList must)
        {
            //***********************************************
            //ArrayList must = new ArrayList {  };
            //***********************************************


            #region 显示

            Console.Write("参加抽奖的总人数： " + totalNum);
            Console.Write("\n每次中奖的人数： " + perNum);
            Console.Write("      抽奖的次数： " + times);

            int nums = times * perNum;
            Console.WriteLine("     中奖人数为： " + nums);

            if (nums > totalNum)
            {
                Console.WriteLine("\n中奖人数多于参加人数，请重新设定。\n");
                Console.ReadLine();
                return;
            }
            #endregion

            //生成数组，长度为参加的人数
            ArrayList al = new ArrayList();
            for (int i = 0; i < totalNum; i++)
            {
                al.Add(i + 1);
            }

            #region 判断设置是否正确
            bool flag = true;
            foreach (int p in must)
            {
                if (!al.Contains(p))
                {
                    flag = false;
                    break;
                }
            }
            #endregion

            ArrayList a = new ArrayList();
            if (flag == false)//设置不正确，按原始数据抽取
            {
                a = RandomArray(al, nums);
            }
            else//设置正确
            {
                #region 抽奖
                int mustNum = must.Count;
                if (nums <= mustNum)
                {
                    a = RandomArray(must, nums);
                }
                else
                {
                    foreach (int p in must)
                    {
                        al.Remove(p);
                    }
                    ArrayList t = new ArrayList();
                    t = RandomArray(al, nums - mustNum);
                    foreach (int p in must)
                    {
                        t.Add(p);
                    }
                    a = RandomArray(t, nums);
                }
                #endregion
            }
            Console.WriteLine("\n恭喜以下人员中奖！");
            for (int i = 0; i < nums; i++)
            {
                Console.Write(a[i] + " ");
                if ((i + 1) % perNum == 0)
                {
                    Console.WriteLine("");
                }
            }



        }
        static void Main(string[] args)
        {
            ArrayList must = new ArrayList { 1, 9 };

            Lucky(10, 2, 3, must);//(总的参加人数,每次中奖的人数,抽奖的次数)

            Console.ReadLine();

        }
    }
}
