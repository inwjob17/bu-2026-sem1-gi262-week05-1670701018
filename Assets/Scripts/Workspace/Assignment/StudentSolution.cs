using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture
        public int[] LCT01_SelectionSortAscending(int[] numbers)
        {
            int n = numbers.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                // วนหาตำแหน่งที่มีค่าน้อยที่สุดในส่วนที่เหลือ
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // สลับค่าตัวที่น้อยที่สุดมาไว้ที่ตำแหน่งปัจจุบัน i
                int temp = numbers[minIndex];
                numbers[minIndex] = numbers[i];
                numbers[i] = temp;
            }

            // แสดงผลลัพธ์ทีละบรรทัดตาม Expected Output
            foreach (int num in numbers)
            {
                Debug.Log(num);
            }

            // ต้องคืนค่า int[] กลับไปด้วย
            return numbers;
        }

        public int[] LCT02_BubbleSortAscending(int[] numbers)
        {
            int n = numbers.Length;

            // Outer loop: วนรอบตามจำนวนสมาชิก
            for (int i = 0; i < n - 1; i++)
            {
                // Inner loop: เปรียบเทียบคู่ที่อยู่ติดกัน
                for (int j = 0; j < n - 1 - i; j++)
                {
                    // ถ้าตัวซ้ายมากกว่าตัวขวา ให้สลับตำแหน่ง
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            // แสดงผลลัพธ์ออก Console ทีละบรรทัด
            foreach (int num in numbers)
            {
                Debug.Log(num);
            }

            return numbers;
        }

        public int[] LCT03_InsertionSortAscending(int[] numbers)
        {
            int n = numbers.Length;

            for (int i = 1; i < n; i++)
            {
                int key = numbers[i];
                int j = i - 1;

                // ขยับตัวที่มากกว่า key ไปทางขวา 1 ตำแหน่ง
                while (j >= 0 && numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }

                // แทรก key ลงในตำแหน่งที่ถูกต้อง
                numbers[j + 1] = key;
            }

            // แสดงผลลัพธ์ออก Console
            foreach (int num in numbers)
            {
                Debug.Log(num);
            }

            return numbers;
        }

        #endregion

        #region Assignment

        public int[] AS01_SelectionSortDescending(int[] numbers)
        {
            int n = numbers.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;

                // วนหาตำแหน่งที่มีค่า "มากที่สุด" ในส่วนที่เหลือ
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] > numbers[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                // สลับค่าตัวที่มากที่สุดมาไว้ที่ตำแหน่งปัจจุบัน i
                int temp = numbers[maxIndex];
                numbers[maxIndex] = numbers[i];
                numbers[i] = temp;
            }

            return numbers;
        }

        public int[] AS02_BubbleSortDescending(int[] numbers)
        {
            int n = numbers.Length;

            // Outer loop: วนรอบตามจำนวนสมาชิก
            for (int i = 0; i < n - 1; i++)
            {
                // Inner loop: เปรียบเทียบคู่ที่อยู่ติดกัน
                for (int j = 0; j < n - 1 - i; j++)
                {
                    // ถ้าตัวซ้ายน้อยกว่าตัวขวา ให้สลับตำแหน่ง (ดันค่าน้อยไปทางขวา)
                    if (numbers[j] < numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            return numbers;
        }

        public int[] AS03_InsertionSortDescending(int[] numbers)
        {
            int n = numbers.Length;

            for (int i = 1; i < n; i++)
            {
                int key = numbers[i];
                int j = i - 1;

                // ขยับตัวที่มีค่าน้อยกว่า key ไปทางขวา 1 ตำแหน่ง
                while (j >= 0 && numbers[j] < key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }

                // แทรก key ลงในตำแหน่งที่ถูกต้อง
                numbers[j + 1] = key;
            }

            return numbers;
        }

        public int AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
            {
                return 0; // กรณีจำนวนข้อมูลไม่พอหาอันดับ 2
            }

            int largest = int.MinValue;
            int secondLargest = int.MinValue;

            foreach (int num in numbers)
            {
                if (num > largest)
                {
                    secondLargest = largest;
                    largest = num;
                }
                else if (num > secondLargest && num != largest)
                {
                    secondLargest = num;
                }
            }

            return secondLargest;
        }

        #endregion

        #region Extra

        public int EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            // ใช้ HashSet เพื่อให้ค้นหาข้อมูลได้เร็ว O(1) และตัดค่าซ้ำ
            HashSet<int> numSet = new HashSet<int>(numbers);
            int longestStreak = 0;

            foreach (int num in numSet)
            {
                // ตรวจสอบว่าเป็นจุดเริ่มต้นของลำดับหรือไม่ (ไม่มี num - 1)
                if (!numSet.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    // นับความยาวของลำดับที่ต่อกันไปเรื่อยๆ (num + 1, num + 2, ...)
                    while (numSet.Contains(currentNum + 1))
                    {
                        currentNum += 1;
                        currentStreak += 1;
                    }

                    // บันทึกความยาวที่มากที่สุด
                    if (currentStreak > longestStreak)
                    {
                        longestStreak = currentStreak;
                    }
                }
            }

            return longestStreak;
        }

        #endregion
    }
}