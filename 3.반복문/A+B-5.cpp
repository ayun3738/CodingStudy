#include <stdio.h>

int main()
{
    // input : (int) A, B

    int A, B;
    scanf("%d %d", &A, &B);
    while (A != 0 && B != 0)
    {
        printf("%d\n", A + B);
        scanf("%d %d", &A, &B);
    }
    return 0;
}