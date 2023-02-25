Console.Clear();
Console.Write("seminar_8 task_61\n\n");


int factorial(int n){
    int res = 1;
    for (int i = 1; i <= n; i++){
        res *= i;
    }
    return res;
}


void pask_lines(ref int lines_amt){
    for (int line = 0; line < lines_amt; line++){
        for (int space = 0; space <= (lines_amt - line); space++){
            Console.Write(" ");
        }
        for (int num_point = 0; num_point <= line; num_point++){
            Console.Write($" {factorial(line) / (factorial(num_point) * factorial(line - num_point))}");
        }
        Console.Write("\n");
    }
}


Console.Write("введите количество строк треугольника Паскаля: ");
int amt = Convert.ToInt32(Console.ReadLine());
pask_lines(ref amt);