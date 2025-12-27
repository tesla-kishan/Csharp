int[] arr1 = {1, 3, 5};
int[] arr2 = {2, 4, 6};

int a = arr1.Length;
int b = arr2.Length;
int [] arr = new int[a+b];

int i=0 ;
int j=0;
int k=0;

while(i<a && j<b)
{
    if (arr1[i] <= arr2[j])
    {
        arr[k]=arr1[i];
        k++;
        i++;
    }
    else
    {
        arr[k]=arr2[j];
        k++;
        j++;
    }
}

while(i<a) arr[k++]=arr1[i++];
while(j<b) arr[k++]=arr2[j++];


foreach(int x in arr)
{
    Console.Write(x+" ");
}