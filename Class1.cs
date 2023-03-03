using System;

public class Matrix
{
	public static double[][] MatrixInverse(double[][] matrix)
	{
		int n = matrix.Length;
		double[][] result = MatrixCreate(n, n);
		for (int i = 0; i < n; ++i)
			for (int j = 0; j < n; ++j)
				result[i][j] = matrix[i][j];
	}
}
