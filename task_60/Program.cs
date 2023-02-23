Console.Clear();
Console.Write("seminar_8 task_60\n\n");

void print_array(ref int[] array){
    for (int i = 0; i < array.Length; i++){
        Console.Write($"{array[i]} ");
    }
    Console.Write("\n\n");
}

void print2Darray(ref int[,] array){
    for (int row = 0; row < array.GetLength(0); row++){
        for (int col = 0; col < array.GetLength(1); col++){
            Console.Write($"{array[row, col]}\t");
        }
        Console.Write("\n");
    }
    Console.Write("\n");
}

int abs(int num){
    if (num < 0){
        return num * (-1);
    }
    return num;
}

int[,] randomUnique2Darray(int rows=2, int cols=2, int min=-2, int max=2){
    int unique_amt = max - min;
    int arr_size = rows * cols;
    if (max > min && rows > 0 && cols >0){
        if (unique_amt >= arr_size){

            // блок формирования проверочных массивов для позитивных и негативных значений
            int positives_amt = 0;
            int negatives_amt = 0;
            for (int num = min; num < max; num ++){
                if (num > (-1)){
                    positives_amt += 1;
                }
                else {
                    negatives_amt += 1;
                }
            }
            int[] unique_pos_arr = new int[max];
            int[] unique_neg_arr = new int[abs(min) + 1];
            // блок формирования проверочных массивов для позитивных и негативных значений

            int[,] array2D = new int[rows, cols];
            for (int row = 0; row < array2D.GetLength(0); row++){
                for (int col = 0; col < array2D.GetLength(1); col++){

                    // блок подбора уникального значения для ячейки
                    int unique_num;
                    while (true){
                        unique_num = new Random().Next(min, max);
                        if (unique_num > -1 && positives_amt > 0){
                            while (unique_pos_arr[unique_num] == 1){
                                unique_num = new Random().Next(0, max);
                            }
                            unique_pos_arr[unique_num] = 1;
                            positives_amt -= 1;
                            break;
                        }
                        else if (unique_num < 0 && negatives_amt > 0){
                            while (unique_neg_arr[abs(unique_num)] == 1){
                                unique_num = new Random().Next(min, 0);
                            }
                            unique_neg_arr[abs(unique_num)] = 1;
                            negatives_amt -= 1;
                            break;
                        }
                    }
                    array2D[row, col] = unique_num;
                    // блок подбора уникального значения для ячейки
                }
            }
            return array2D;
        }
        else {
            Console.Write("двумерный массив с уникальными значениями заданного размера с заданным диапазоном значений не может быть сформирован");
            return new int[,] {{}};
        }
    }
    else {
        Console.Write("в функцию переданы некорректные занчения");
        return new int[,] {{}};
    }
}

int[,] arr = randomUnique2Darray();
print2Darray(ref arr);