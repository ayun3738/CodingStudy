#include <stdio.h>

int main()
{
    // input : (int) N, M
    // input * 2 : (int) arr[N][M]

    int N, M;
    scanf("%d %d", &N, &M);
    
    int arr1[N][M];
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            scanf("%d", &arr1[i][j]);
        }
    }

    int arr2[N][M];
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            scanf("%d", &arr2[i][j]);
        }
    }

    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            printf("%d ", arr1[i][j] + arr2[i][j]);
        }
        printf("\n");
    }

    return 0;

}