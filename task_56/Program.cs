Console.Clear();
Console.Write("seminar_8 task_56\n\n");

void print2Darray(ref int[,] array){
    for (int row = 0; row < array.GetLength(0); row++){
        for (int col = 0; col < array.GetLength(1); col++){
            Console.Write($"{array[row, col]} ");
        }
        Console.Write("\n");
    }
    Console.Write("\n");
}

int[,] random2Darray(int rows=4, int cols=4, int min=0, int max=10){
    int[,] array2D = new int[rows, cols];
    for (int row = 0; row < array2D.GetLength(0); row++){
        for (int col = 0; col < array2D.GetLength(1); col++){
            array2D[row, col] = new Random().Next(min, max);
        }
    }
    return array2D;
}

int minrow(ref int[,] arr){
    int row_summa;
    int min_summa = 0;
    int min_row = 0;
    for (int col = 0; col < arr.GetLength(1); col++){
        min_summa += arr[min_row, col];
    }
    Console.Write($"{min_row + 1} -> {min_summa}\n");
    for (int row = 1; row < arr.GetLength(0); row++){
        row_summa = 0;
        for (int col = 0; col < arr.GetLength(1); col++){
            row_summa += arr[row, col];
        }
        Console.Write($"{row + 1} -> {row_summa}\n");
        if (row_summa < min_summa){
            min_summa = row_summa;
            min_row = row;
        }
    }
    return min_row + 1;
}

int[,] arr = random2Darray(4, 6);
Console.Write("заданый массив:\n");
print2Darray(ref arr);
Console.Write($"номер строки с наименьшей суммой элементов -> {minrow(ref arr)}");