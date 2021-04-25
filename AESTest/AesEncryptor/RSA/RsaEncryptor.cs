﻿using Encryptors.Rsa;
using Encryptors.RSA.Exceptions;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Encryptors.Rsa
{
    public class RsaEncryptor : IEncryptor
    {
        public RsaEncryptor()
        {
            GenerateKeys();
        }
        public int KeyLenght { get; private set; } = 2048;
        private RSACryptoServiceProvider CSP;
        public RSAParameters PrivateKey { get; private set; }
        public RSAParameters PublicKey { get; private set; }

        public void GenerateKeys()
        {
            CSP = new RSACryptoServiceProvider();
            PrivateKey = CSP.ExportParameters(true);
            PublicKey = CSP.ExportParameters(false);
        }
        public byte[] Decrypt(byte[] data, RSAParameters privateKey)
        {
            return DefaultDecrypt(data, privateKey);
        }
        public byte[] Encrypt(byte[] data, RSAParameters publicKey)
        {
            return DefaultEncrypt(data, publicKey);
        }
        private byte[] DefaultDecrypt(byte[] encData, RSAParameters privateKey)
        {
            CSP.ImportParameters(privateKey);
            return CSP.Decrypt(encData, false);
        }
        private byte[] DefaultEncrypt(byte[] data, RSAParameters publicKey)
        {
            CSP.ImportParameters(publicKey);
            return CSP.Encrypt(data, false);
        }
    }
}
