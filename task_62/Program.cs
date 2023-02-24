Console.Clear();
Console.Write("seminar_8 task_62\n\n");


void print2Darray(ref int[,] array){
    for (int row = 0; row < array.GetLength(0); row++){
        for (int col = 0; col < array.GetLength(1); col++){
            Console.Write($"{array[row, col]}\t");
        }
        Console.Write("\n");
    }
    Console.Write("\n");
}


void set_direct(ref int[] curr_direct, ref string str_direct){
    if (str_direct == "right"){
        curr_direct[0] = 0;
        curr_direct[1] = 1;
    }
    else if (str_direct == "down"){
        curr_direct[0] = 1;
        curr_direct[1] = 0;
    }
    else if (str_direct == "left"){
        curr_direct[0] = 0;
        curr_direct[1] = -1;
    }
    else if (str_direct == "up"){
        curr_direct[0] = -1;
        curr_direct[1] = 0;
    }
}


bool no_way(ref int up_edge,
            ref int left_edge,
            ref int down_edge,
            ref int right_edge,
            ref string curr_str_direct,
            ref int row, ref int col){
    if (curr_str_direct == "right" && col + 1 == right_edge){
        right_edge = col;
        return true;
    }
    else if (curr_str_direct == "down" && row + 1 == down_edge){
        down_edge = row;
        return true;
    }
    else if (curr_str_direct == "left" && col - 1 == left_edge){
        left_edge = col;
        return true;
    }
    else if (curr_str_direct == "up" && row - 1 == up_edge){
        up_edge = row;
        return true;
    }
    return false;
}


int[,] matrix = new int[10, 10];

int up_edge = 0;
int left_edge = -1;
int down_edge = matrix.GetLength(0);
int right_edge = matrix.GetLength(1);

string[] directs_arr = {"right", "down", "left", "up"};
int dir_index = 0;
string curr_str_direct = directs_arr[dir_index];
int[] curr_direct = new int[2];

set_direct(ref curr_direct, ref curr_str_direct);
dir_index += 1;

int nap = 1;

int row = 0;
int col = 0;
while(nap < matrix.GetLength(0) * matrix.GetLength(1) + 1){
    if (no_way(ref up_edge, ref left_edge, ref down_edge, ref right_edge, ref curr_str_direct, ref row, ref col)){
        curr_str_direct = directs_arr[dir_index];
        dir_index += 1;
        if (dir_index > 3){
            dir_index = 0;
        }
        set_direct(ref curr_direct, ref curr_str_direct);
    }
    matrix[row, col] = nap;
    nap += 1;
    row += curr_direct[0];
    col += curr_direct[1];
}
print2Darray(ref matrix);