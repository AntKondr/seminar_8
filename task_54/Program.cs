Console.Clear();
Console.Write("seminar_8 task_54\n\n");

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

// сортировка массива методом выбора
void sort(ref int[,] array, bool revers=false){
    if (revers){
        for (int row = 0; row < array.GetLength(0); row++){
            for (int i = 0; i < (array.GetLength(1) - 1); i++){
                int max = array[row, i];
                int max_index = i;
                for (int j = i + 1; j < array.GetLength(1); j++){
                    if (array[row, j] > max){
                        max = array[row, j];
                        max_index = j;
                    }
                }
                int curr = array[row, i];
                array[row, i] = max;
                array[row, max_index] = curr;
            }
        }
    }
    else {
        for (int row = 0; row < array.GetLength(0); row++){
            for (int i = 0; i < (array.GetLength(1) - 1); i++){
                int min = array[row, i];
                int min_index = i;
                for (int j = i + 1; j < array.GetLength(1); j++){
                    if (array[row, j] < min){
                        min = array[row, j];
                        min_index = j;
                    }
                }
                int curr = array[row, i];
                array[row, i] = min;
                array[row, min_index] = curr;
            }
        }
    }
}

int[,] arr = random2Darray(rows: 4, cols: 6);
Console.Write("исходный массив:\n");
print2Darray(ref arr);
sort(ref arr, revers: true);
Console.Write("отсортированный по убыванию массив:\n");
print2Darray(ref arr);