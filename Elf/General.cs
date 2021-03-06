﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Elf
{
   public static class General
    {
       public static String ToString(this String s)
       {
           return s;
       }
       /// <summary>
       /// 小写
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public static String Lower(this String s)
       {
           return s.ToLower();
       }
       /// <summary>
       /// 大写
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public static String Capital(this String s)
       {
           return s.ToUpper();
       }
       #region Base64加密解密
       /// <summary>
       /// Base64加密
       /// </summary>
       /// <param name="input">需要加密的字符串</param>
       /// <returns></returns>
       public static String Base64Encrypt(this String input)
       {
           return Base64Encrypt(input, new UTF8Encoding());
       }

       /// <summary>
       /// Base64加密
       /// </summary>
       /// <param name="input">需要加密的字符串</param>
       /// <param name="encode">字符编码</param>
       /// <returns></returns>
       public static String Base64Encrypt(this String input, Encoding encode)
       {
           return Convert.ToBase64String(encode.GetBytes(input));
       }

       /// <summary>
       /// Base64解密
       /// </summary>
       /// <param name="input">需要解密的字符串</param>
       /// <returns></returns>
       public static String Base64Decrypt(this String input)
       {
           return Base64Decrypt(input, new UTF8Encoding());
       }

       /// <summary>
       /// Base64解密
       /// </summary>
       /// <param name="input">需要解密的字符串</param>
       /// <param name="encode">字符的编码</param>
       /// <returns></returns>
       public static String Base64Decrypt(this String input, Encoding encode)
       {
           return encode.GetString(Convert.FromBase64String(input));
       }
       #endregion

       #region DES加密解密
       /// <summary>
       /// DES加密
       /// </summary>
       /// <param name="data">加密数据</param>
       /// <param name="key">8位字符的密钥字符串</param>
       /// <param name="iv">8位字符的初始化向量字符串</param>
       /// <returns></returns>
       public static String DESEncrypt(this String data, string key, string iv)
       {
           byte[] byKey = Encoding.ASCII.GetBytes(key);
           byte[] byIV = Encoding.ASCII.GetBytes(iv);
           DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
           MemoryStream ms = new MemoryStream();
           CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);
           StreamWriter sw = new StreamWriter(cst);
           sw.Write(data);
           sw.Flush();
           cst.FlushFinalBlock();
           sw.Flush();
           return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
       }

       /// <summary>
       /// DES解密
       /// </summary>
       /// <param name="data">解密数据</param>
       /// <param name="key">8位字符的密钥字符串(需要和加密时相同)</param>
       /// <param name="iv">8位字符的初始化向量字符串(需要和加密时相同)</param>
       /// <returns></returns>
       public static String DESDecrypt(this String data, string key, string iv)
       {
           byte[] byKey = Encoding.ASCII.GetBytes(key);
           byte[] byIV = Encoding.ASCII.GetBytes(iv);

           byte[] byEnc;
           try
           {
               byEnc = Convert.FromBase64String(data);
           }
           catch
           {
               return null;
           }

           DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
           MemoryStream ms = new MemoryStream(byEnc);
           CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
           StreamReader sr = new StreamReader(cst);
           return sr.ReadToEnd();
       }
       #endregion

       #region MD5加密
       /// <summary>
       /// MD5加密
       /// </summary>
       /// <param name="input">需要加密的字符串</param>
       /// <returns></returns>
       public static String MD5Encrypt(this String input)
       {
           return MD5Encrypt(input, new UTF8Encoding());
       }

       /// <summary>
       /// MD5加密
       /// </summary>
       /// <param name="input">需要加密的字符串</param>
       /// <param name="encode">字符的编码</param>
       /// <returns></returns>
       public static String MD5Encrypt(this String input, Encoding encode)
       {
           MD5 md5 = new MD5CryptoServiceProvider();
           byte[] t = md5.ComputeHash(encode.GetBytes(input));
           StringBuilder sb = new StringBuilder(32);
           for (int i = 0; i < t.Length; i++)
               sb.Append(t[i].ToString("x").PadLeft(2, '0'));
           return sb.ToString();
       }

       /// <summary>
       /// MD5对文件流加密
       /// </summary>
       /// <param name="stream"></param>
       /// <returns></returns>
       public static String MD5Encrypt(this Stream stream)
       {
           MD5 md5serv = MD5.Create();
           byte[] buffer = md5serv.ComputeHash(stream);
           StringBuilder sb = new StringBuilder();
           foreach (byte var in buffer)
               sb.Append(var.ToString("x2"));
           return sb.ToString();
       }

       /// <summary>
       /// MD5加密(返回16位加密串)
       /// </summary>
       /// <param name="input"></param>
       /// <param name="encode"></param>
       /// <returns></returns>
       public static String MD5Encrypt16(this String input, Encoding encode)
       {
           MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
           string result = BitConverter.ToString(md5.ComputeHash(encode.GetBytes(input)), 4, 8);
           result = result.Replace("-", "");
           return result;
       }
       #endregion

       #region 3DES 加密解密

       public static String DES3Encrypt(this String data, string key)
       {
           TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

           DES.Key = Encoding.ASCII.GetBytes(key);
           DES.Mode = CipherMode.CBC;
           DES.Padding = PaddingMode.PKCS7;

           ICryptoTransform DESEncrypt = DES.CreateEncryptor();

           byte[] Buffer = Encoding.ASCII.GetBytes(data);
           return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
       }

       public static String DES3Decrypt(this String data, string key)
       {
           TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider
           {
               Key = Encoding.ASCII.GetBytes(key),
               Mode = CipherMode.CBC,
               Padding = PaddingMode.PKCS7
           };


           ICryptoTransform DESDecrypt = DES.CreateDecryptor();

           string result = "";
           try
           {
               byte[] Buffer = Convert.FromBase64String(data);
               result = Encoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
           }
           catch
           {
               // ignored
           }
           return result;
       }

       #endregion
    }
  
}
