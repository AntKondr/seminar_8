Console.Clear();
Console.Write("seminar_8 task_60\n\n");

void print3Darray(ref int[,,] array3D){
    for (int row = 0; row < array3D.GetLength(0); row++){
        for (int col = 0; col < array3D.GetLength(1); col++){
            for (int depth = 0; depth < array3D.GetLength(2); depth++){
                Console.Write($"{array3D[row, col, depth]} ({row},{col},{depth})\t");
            }
            Console.Write("\n");
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

bool digits_amt(int num, ref int req_dig_amt){
    int dig_amt = 1;
    num = num / 10;
    while (num != 0){
        num = num / 10;
        dig_amt += 1;
    }
    if (dig_amt == req_dig_amt){
        return true;
    }
    return false;
}

int[,,] randomUnique2Darray(int rows=2, int cols=2, int depths=2, int min=-9, int max=10, int digits=1){
    int unique_amt = max - min;
    int arr_size = rows * cols * depths;
    if (max > min && rows > 0 && cols > 0 && depths > 0){
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

            int[,,] array3D = new int[rows, cols, depths];
            for (int row = 0; row < array3D.GetLength(0); row++){
                for (int col = 0; col < array3D.GetLength(1); col++){
                    for (int depth = 0; depth < array3D.GetLength(2); depth++){

                        // блок подбора уникального значения для ячейки
                        int unique_num;
                        while (true){
                            unique_num = new Random().Next(min, max);
                            //if (digits_amt(unique_num, ref digits)){
                                if (unique_num > -1 && positives_amt > 0){
                                    while (unique_pos_arr[unique_num] == 1){
                                        unique_num = new Random().Next(0, max);
                                        // while (!digits_amt(unique_num, ref digits)){
                                        //     unique_num = new Random().Next(0, max);
                                        // }
                                    }
                                    unique_pos_arr[unique_num] = 1;
                                    positives_amt -= 1;
                                    break;
                                }
                                else if (unique_num < 0 && negatives_amt > 0){
                                    while (unique_neg_arr[abs(unique_num)] == 1){
                                        unique_num = new Random().Next(min, 0);
                                        // while (!digits_amt(unique_num, ref digits)){
                                        //     unique_num = new Random().Next(min, 0);
                                        // }
                                    }
                                    unique_neg_arr[abs(unique_num)] = 1;
                                    negatives_amt -= 1;
                                    break;
                                }
                            //}
                        }
                        array3D[row, col, depth] = unique_num;
                        // блок подбора уникального значения для ячейки
                    }
                }
            }
            return array3D;
        }
        else {
            Console.Write("двумерный массив с уникальными значениями заданного размера с заданным диапазоном значений не может быть сформирован");
            return new int[,,] {};
        }
    }
    else {
        Console.Write("в функцию переданы некорректные занчения");
        return new int[,,] {};
    }
}

int[,,] arr = randomUnique2Darray(rows: 70, cols: 70, depths: 70, min: 0, max: 3430000, digits: 5);
print3Darray(ref arr);



// int qwerty = 17;
// int reqqdig = 3;
// if (digits_amt(qwerty, ref reqqdig)){
//     Console.Write($"{qwerty} имеет {reqqdig} знака");
// }