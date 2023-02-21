Console.Clear();
Console.Write("seminar_8 task_58\n\n");

void print2Darray(ref int[,] array){
    for (int row = 0; row < array.GetLength(0); row++){
        for (int col = 0; col < array.GetLength(1); col++){
            Console.Write($"{array[row, col]}\t");
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

int[,] mul_matr(ref int[,] matrixA, ref int[,] matrixB){
    if (matrixA.GetLength(1) == matrixB.GetLength(0)){
        int[,] matrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
        int vec_len = matrixA.GetLength(1);

        // код умножения матриц
        for (int rowC = 0; rowC < matrixC.GetLength(0); rowC++){
            for (int colC = 0; colC < matrixC.GetLength(1); colC++){
                // код вычисления ячейки матрицы C
                int res = 0;
                for (int pos = 0; pos < vec_len; pos++){
                    res += matrixA[rowC, pos] * matrixB[pos, colC];
                }
                matrixC[rowC, colC] = res;
                // код вычисления ячейки матрицы C
            }
        }
        // код умножения матриц

        return matrixC;
    }
    else {
        Console.Write("произведение матриц невозможно\n");
        return new int[,] {{}};
    }
}

int[,] matrixA = random2Darray(3, 2);
int[,] matrixB = random2Darray(2, 3);
Console.Write("matrixA:\n");
print2Darray(ref matrixA);
Console.Write("matrixB:\n");
print2Darray(ref matrixB);

int[,] matrixC = mul_matr(ref matrixA, ref matrixB);
Console.Write("matrixA * matrixB =\n");
print2Darray(ref matrixC);