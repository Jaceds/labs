#include <stdio.h>
#include <stdlib.h>
#include <time.h>
int main()
{
    int max = 100,
        min = -100,
        array[5][7],
        newArray[7],
        maxOfArray;

    srand(time(NULL));

    for (int i = 0; i < 5; i++)
        for (int a = 0; a < 7; a++)
            array[i][a] = rand() % (min - max + 1) + min;

    printf("Прямокутна матриця з згенерованими значеннями\n");
    for (int i = 0; i < 5; i++)
    {
        for (int a = 0; a < 7; a++)
            printf("%d\t", array[i][a]);

        printf("\n");
    }

    for (int a = 0; a < 7; a++)
    {
        maxOfArray = array[0][a];
        for (int i = 0; i < 5; i++)
        {

            if (array[i][a] >= maxOfArray)
            {
                maxOfArray = array[i][a];
                newArray[a] = maxOfArray;
            }
            else if (array[i][a] <= maxOfArray)
            {
                newArray[a] = maxOfArray;
            }
        }
    }
    printf("Массив  із максимальними значеннями чисел для кожного стовбця в прямокутній матриці \n");
    for (int i = 0; i < 7; i++)
    {
        printf("%d \t", newArray[i]);
    }
    printf("\n");
}