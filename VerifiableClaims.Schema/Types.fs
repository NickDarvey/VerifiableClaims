namespace NickDarvey.VerifiableClaims.Schema

open System

type set<'T when 'T : comparison> = System.Collections.Immutable.IImmutableSet<'T>

type SignatureType = SignatureType of string
type Signature = {
    Type: SignatureType
}

type ProfileId = ProfileId of Uri
type ProfileType = ProfileType of string
type Profile = { 
    Id: ProfileId
    Type: ProfileType set
    Signature: Signature option
}

type RevocationId = RevocationId of Uri
type RevocationType = RevocationType of string
type Revocation = {
    Id: RevocationId
    Type: RevocationType set
}

type CredentialId = CredentialId of Uri
type CredentialType = CredentialType of string
type Claim = { Id: ProfileId }
type Credential = {
    Id: CredentialId
    Type: CredentialType set
    Issuer: ProfileId
    Issued: DateTimeOffset
    Expires: DateTimeOffset option
    Claim: Claim
    Revocation: Revocation option
    Signature: Signature option
}
