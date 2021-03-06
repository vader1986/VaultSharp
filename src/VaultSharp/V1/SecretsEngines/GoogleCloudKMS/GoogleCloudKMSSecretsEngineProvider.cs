﻿using System.Net.Http;
using System.Threading.Tasks;
using VaultSharp.Core;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.SecretsEngines.GoogleCloudKMS
{
    internal class GoogleCloudKMSSecretsEngineProvider : IGoogleCloudKMSSecretsEngine
    {
        private readonly Polymath _polymath;

        public GoogleCloudKMSSecretsEngineProvider(Polymath polymath)
        {
            _polymath = polymath;
        }

        public async Task<Secret<EncryptionResponse>> EncryptAsync(string keyName, EncryptRequestOptions encryptRequestOptions, string mountPoint = SecretsEngineDefaultPaths.GoogleCloudKMS, string wrapTimeToLive = null)
        {
            Checker.NotNull(keyName, "keyName");
            Checker.NotNull(encryptRequestOptions, "encryptRequestOptions");

            return await _polymath.MakeVaultApiRequest<Secret<EncryptionResponse>>("v1/" + mountPoint.Trim('/') + "/encrypt/" + keyName.Trim('/'), HttpMethod.Post, encryptRequestOptions, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<DecryptionResponse>> DecryptAsync(string keyName, DecryptRequestOptions decryptRequestOptions, string mountPoint = SecretsEngineDefaultPaths.GoogleCloudKMS, string wrapTimeToLive = null)
        {
            Checker.NotNull(keyName, "keyName");
            Checker.NotNull(decryptRequestOptions, "decryptRequestOptions");

            return await _polymath.MakeVaultApiRequest<Secret<DecryptionResponse>>("v1/" + mountPoint.Trim('/') + "/decrypt/" + keyName.Trim('/'), HttpMethod.Post, decryptRequestOptions, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<ReEncryptionResponse>> ReEncryptAsync(string keyName, ReEncryptRequestOptions reEncryptRequestOptions, string mountPoint = SecretsEngineDefaultPaths.GoogleCloudKMS, string wrapTimeToLive = null)
        {
            Checker.NotNull(keyName, "keyName");
            Checker.NotNull(reEncryptRequestOptions, "reEncryptRequestOptions");

            return await _polymath.MakeVaultApiRequest<Secret<ReEncryptionResponse>>("v1/" + mountPoint.Trim('/') + "/reencrypt/" + keyName.Trim('/'), HttpMethod.Post, reEncryptRequestOptions, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<SignatureResponse>> SignAsync(string keyName, SignatureOptions signatureOptions, string mountPoint = SecretsEngineDefaultPaths.GoogleCloudKMS, string wrapTimeToLive = null)
        {
            Checker.NotNull(keyName, "keyName");
            Checker.NotNull(signatureOptions, "signatureOptions");

            return await _polymath.MakeVaultApiRequest<Secret<SignatureResponse>>("v1/" + mountPoint.Trim('/') + "/sign/" + keyName.Trim('/'), HttpMethod.Post, signatureOptions, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<VerificationResponse>> VerifyAsync(string keyName, VerificationOptions verificationOptions, string mountPoint = SecretsEngineDefaultPaths.GoogleCloudKMS, string wrapTimeToLive = null)
        {
            Checker.NotNull(keyName, "keyName");
            Checker.NotNull(verificationOptions, "verificationOptions");

            return await _polymath.MakeVaultApiRequest<Secret<VerificationResponse>>("v1/" + mountPoint.Trim('/') + "/verify/" + keyName.Trim('/'), HttpMethod.Post, verificationOptions, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }
    }
}