﻿// Имеется список чисел. Создайте список, в который попадают числа, описывающие максимальную возрастающую последовательность. 
// Порядок элементов менять нельзя.

int[] createUnicArray(int min, int max, int length){
	int	count = 0;
	int[] array = new int[length];
	while(count < length){
		int number = new Random().Next(min,max+1);
		bool unic = true;
		for(int i = 0; i < count; i++){
			if(number == array[i]){
				unic = false;
				break;
			}
		}
		if(unic){
			array[count] = number;
			count += 1;
		} 
	}
	return array;
}

void printArray(int[] array){
	foreach(int element in array){
		Console.Write($"{element} ");
	}
	Console.WriteLine();
}

int[] findMinMax(int[] array, int[]disI){
	int[] result = new int[4];
	int length = array.Length;

	printArray(disI);
	for (int i = 0; i < length; i++){
		if(disI[i] == 0){
			result[0] = i;
			result[1] = i;
			result[2] = array[i];
			result[3] = array[i];
			break;
		}
	}
	for (int i = 0; i < length; i++){
		if(disI[i] == 0){
			if(array[i] < result[2]){
				result[0] = i;
				result[2] = array[i];
			}
			else if(array[i] > result[3]){
				result[1] = i;
				result[3] = array[i];
			}
		}
	}
	return result;
}
void findMaxSubsequence(int[] array, int[]disI, int[] result){
	int[] minMax = findMinMax(array, disI);
	int length = array.Length;
	int next = minMax[2] + 1;
	int countNumS = 1;
	bool flag = false;
	int[] preRes = new int[2];

	disI[minMax[0]] = 1;
	preRes[0] = minMax[2];
	preRes[1] = minMax[2];
	while (next <= minMax[3]){
		flag = false;
		for(int i = 0; i < length; i++){
			if(array[i] == next){
				disI[i] = 1;
				preRes[1] = array[i];
				flag = true;
				countNumS += 1;
				break;
			}
		}
		Console.WriteLine($"countNumS {countNumS} pre[0]{preRes[0]} pre[1]{preRes[1]} result{result[0]} {result[1]}");
		if(flag){
			next += 1;
		}else{
			if(countNumS > 1){
				if(countNumS > length/2){
					result[0] = preRes[0];
					result[1] = preRes[1];
					break;
				}
				else if(result[1] - result[0] < preRes[1] - preRes[0]){
					Console.WriteLine("да");
					result[0] = preRes[0];
					result[1] = preRes[1];
				}
			}
			findMaxSubsequence(array, disI, result);
			break;
		}
	}
}

int min = 1,
	max = 14,
	length = 9;
int[] array = createUnicArray(min, max, length);
printArray(array);
int[] disIndex = new int[length];
int[] result = new int[2]{0, 0};
findMaxSubsequence(array, disIndex, result);
printArray(result);