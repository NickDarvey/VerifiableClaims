namespace NickDarvey.VerifiableClaims

[<AutoOpen>]
module Types =
    open System

    type set<'T when 'T : comparison> = System.Collections.Immutable.IImmutableSet<'T>

    type ProofType = SignatureType of string
    type Proof = {
        Type: ProofType
    }

    type ProfileId = ProfileId of Uri
    type ProfileType = ProfileType of string
    type Profile = { 
        Id: ProfileId
        Type: ProfileType set
        Proof: Proof option
    }

    type CredentialStatusId = RevocationId of Uri
    type CredentialStatusType = RevocationType of string
    type CredentialStatus = {
        Id: CredentialStatusId
        Type: CredentialStatusType set
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
        CredentialStatus: CredentialStatus option
        Proof: Proof option
    }

    type PresentationId = PresentationId of Uri
    type PresentationType = PresentationType of string
    type Presentation = {
        Id: PresentationId
        Type: PresentationType set
        VerifiableCredential: Credential list
        Proof: Proof list
    }