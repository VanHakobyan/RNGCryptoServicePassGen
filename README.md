# RNGCryptoService password generator

<p align="center">
<img src="https://i.gyazo.com/01515f43a2b33f5f6fbef3fdcfa6cd74.png">
</p>

Example. The most useful method on RNGCryptoServiceProvider is the GetBytes method. And because this type implements Dispose, you can enclose it in a using-statement. We fill a four-byte array with GetBytes ten times.

```C#

using System;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            // Buffer storage.
            byte[] data = new byte[4];

            // Ten iterations.
            for (int i = 0; i < 10; i++)
            {
                // Fill buffer.
                rng.GetBytes(data);

                // Convert to int 32.
                int value = BitConverter.ToInt32(data, 0);
                Console.WriteLine(value);
            }
        }
    }
}

```

## The library consists of

```c#

public enum optionPass
 {
       pasSize,
       pasUpperOnly,
       pasSmallOnly,
       pasDigitOnly,
       pasDigitUpperSmall

}
...
...
...
public Password(optionPass passOpt, int length)
{
      getPassword = NewPassword(passOpt, length).ToString();
}

```





