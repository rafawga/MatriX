int[] vetorA = new int[9] { 1, 2, 3, 2, 5, 6, 2, 5, 8 };
int[] vetorB = new int[9] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
Mat mat1 = new Mat(vetorA);
Mat mat2 = new Mat(vetorB);

mat1 = mat1.Sum(mat2);
mat1.MostrarMatriz();
mat1 = mat1.Sub(mat2);
mat1.MostrarMatriz();
int determinante = mat1.Determinante;
System.Console.WriteLine(determinante);
System.Console.WriteLine();
mat1 = mat1.Mul(mat2);
mat1.MostrarMatriz();
Mat.Empty(mat1);
mat1.MostrarMatriz();
Mat.Identity(mat1);
mat1.MostrarMatriz();

public class Mat
{
    public int[] vetorA;
    public Mat(int[] vetorA)
    {
        this.vetorA = vetorA;
    }

    public int Determinante
    {
        get
        {
            int determinante = 0;

            determinante += vetorA[0] * vetorA[4] * vetorA[8];
            determinante += vetorA[1] * vetorA[5] * vetorA[6];
            determinante += vetorA[2] * vetorA[3] * vetorA[7];
            determinante -= vetorA[2] * vetorA[4] * vetorA[6];
            determinante -= vetorA[0] * vetorA[5] * vetorA[7];
            determinante -= vetorA[1] * vetorA[3] * vetorA[8];

            return determinante;
        }
    }

    public Mat Sum(Mat mat)
    {
        int[] newMatriz = new int[9];
        for (int i = 0; i < 9; i++)
        {
            newMatriz[i] = vetorA[i] + mat.vetorA[i];
        }
        return new Mat(newMatriz);
    }


    public Mat Sub(Mat mat)
    {
        int[] newMatriz = new int[9];
        for (int i = 0; i < 9; i++)
        {
            newMatriz[i] = vetorA[i] - mat.vetorA[i];
        }
        return new Mat(newMatriz);
    }

    public Mat Mul(Mat mat)
    {
        int[] newMatriz = new int[9];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    newMatriz[i * 3 + j] += vetorA[i * 3 + k] * mat.vetorA[k * 3 + j];
                }
            }
        }

        return new Mat(newMatriz);
    }

    public void MostrarMatriz()
    {
        for (int i = 0; i < 9; i += 3)
        {
            System.Console.WriteLine($"{vetorA[i]} {vetorA[i + 1]} {vetorA[i + 2]}");
        }
        System.Console.WriteLine();
    }


    public static void Empty(Mat mat)
    {
        for (int i = 0; i < mat.vetorA.Length; i++)
        {
            mat.vetorA[i] = 0;
        }
    }


    public static void Identity(Mat mat)
    {
        for (int i = 0; i < mat.vetorA.Length; i++)
        {
            mat.vetorA[i] = 0;
            if (i == 0 || i == 4 || i == 8)
                mat.vetorA[i] = 1;
        }
    }
}





