#include <stdio.h>

int main()
{
    // input : (int) T
    // input * T : (int) A, B

    int T;
    scanf("%d", &T);
    for (int i = 1; i <= T; i++)
    {
        int A, B;
        scanf("%d %d", &A, &B);
        printf("Case #%d: %d + %d = %d\n", i, A, B, A + B);
    }
}