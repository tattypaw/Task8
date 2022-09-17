/*Задача 54: Задайте двумерный массив. Напишите программу, 
которая упорядочит по убыванию элементы каждой строки двумерного массива.
*/
/*
int[,] Sorting2dArray(int[,] array){
    for(int i=0; i<array.GetLength(0); i++){
        for(int j=0; j<array.GetLength(1); j++){
            int temp = 0;
            int indexMax = j;
            for (int k = j+1; k<array.GetLength(1); k++){
                if (array[i,indexMax] < array[i,k]) {
                    indexMax = k;
                }
            }
            temp = array[i,indexMax];
            array[i,indexMax] = array[i,j];
            array[i,j] = temp;
        }
    }
    return array;
}

int[,] CreateRandom2dArray(int rows, int cols, int min, int max){
    int[,] array = new int[rows,cols];
    for(int i = 0; i<rows; i++)
        for(int j = 0; j<cols; j++)
            array[i,j] = new Random().Next(min, max+1);
    return array;
}

void Show2dArray(int[,] array){
    for(int i = 0; i<array.GetLength(0); i++){
        for(int j = 0; j<array.GetLength(1); j++){
            Console.Write(array[i,j]+ " ");
        }
        Console.WriteLine();
    }
}

Console.Write("Input numb of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Input numb of cols: ");
int cols = Convert.ToInt32(Console.ReadLine());
Console.Write("Input numb of min: ");
int min = Convert.ToInt32(Console.ReadLine());
Console.Write("Input numb of max: ");
int max = Convert.ToInt32(Console.ReadLine());

int[,] array = CreateRandom2dArray(rows,cols,min,max);
Show2dArray(array);
Console.WriteLine();

array = Sorting2dArray(array);
Show2dArray(array);
*/

/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки 
с наименьшей суммой элементов: 1 строка*/

/*
int[,] CreateRandom2dArray(int rows, int cols, int min, int max){
    int[,] array = new int[rows,cols];
    for(int i = 0; i<rows; i++)
        for(int j = 0; j<cols; j++)
            array[i,j] = new Random().Next(min, max+1);
    return array;
}

void Show2dArray(int[,] array){
    for(int i = 0; i<array.GetLength(0); i++){
        for(int j = 0; j<array.GetLength(1); j++){
            Console.Write(array[i,j]+ " ");
        }
        Console.WriteLine();
    }
}

void MinSumRow2dArray(int[,] array){
    int minRow = 0;
    int sumRow = SumRow(array, 0);
    for(int i=1; i<array.GetLength(0); i++){
        int sum = SumRow(array, i);
        if (sum < sumRow) {
                minRow = i;
                sumRow = sum;
            }
        }
    Console.WriteLine("Минимальная сумма элементов в ряде номер " + minRow);
    }

int SumRow(int[,] array, int i){
    int sum = 0;
    for(int j=0; j<array.GetLength(1); j++){
            sum = sum + array[i,j];
        }
    return sum;
}

Console.Write("Input numb of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Input numb of cols: ");
int cols = Convert.ToInt32(Console.ReadLine());

while(rows == cols){
    Console.Write("Input another numb of cols: ");
    cols = Convert.ToInt32(Console.ReadLine());
}

Console.Write("Input numb of min: ");
int min = Convert.ToInt32(Console.ReadLine());
Console.Write("Input numb of max: ");
int max = Convert.ToInt32(Console.ReadLine());

int[,] array = CreateRandom2dArray(rows,cols,min,max);
Show2dArray(array);
Console.WriteLine();
MinSumRow2dArray(array);
*/
/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07*/

void Show2dArray(int[,] array){
    for(int i = 0; i<array.GetLength(0); i++){
        for(int j = 0; j<array.GetLength(1); j++){
            Console.Write(array[i,j]+ " ");
        }
        Console.WriteLine();
    }
}

int[,] CompletionRowForward (int[,] array, int row, int col, int repeat, int count){
    for(int j=col; j<repeat+col; j++){
            array[row,j] = count;
            count++;
        }
    return array;
}

int[,] CompletionRowBackward (int[,] array, int row, int col, int repeat, int count){
    for(int j=col; j>col-repeat; j--){
            array[row,j] = count;
            count++;
        }
    return array;
}

int[,] CompletionColForward (int[,] array, int row, int col, int repeat, int count){
    for(int j=row; j<repeat+row; j++){
            array[j,col] = count;
            count++;
        }
    return array;
}

int[,] CompletionColBackward (int[,] array, int row, int col, int repeat, int count){
    for(int j=row; j>row-repeat; j--){
            array[j,col] = count;
            count++;
            
        }
    return array;
}

Console.Write("Введите размер массива по горизонтали или вертикали: ");
int n=Convert.ToInt32(Console.ReadLine());
int[,] array = new int[n,n];
int number = 1;
int flag = 1;
int counterRow = 0;
int counterCol = 0;
int i = n;
while(number<n*n){
    if (flag == 1){
        CompletionRowForward (array, counterRow, counterCol, i, number);
        number +=i;
        counterRow += 1;
        i -=1;
        counterCol += i;
        CompletionColForward (array, counterRow, counterCol, i, number);
        number +=i;
        counterCol -= 1;
        counterRow += i-1;
    }
    else{
        CompletionRowBackward (array, counterRow, counterCol, i, number);
        number +=i;
        i -=1;
        counterRow -= 1;
        counterCol -= i;
        CompletionColBackward (array, counterRow, counterCol, i, number);
        number +=i;
        counterRow -= i-1;
        counterCol += 1;
    }
    flag *=-1;
}
int x = n/2;
int y = x - 1 + n%2;
array[x,y] = number;
Show2dArray(array);



