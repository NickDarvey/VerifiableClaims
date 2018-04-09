namespace NickDarvey.VerifiableClaims.Schema

open System


type ProofType = ProofType of string
type ProofSchema = {
    Type: ProofType
}

type ProfileId = ProfileId of Uri
type ProfileType = ProfileType of string


type CredentialId = CredentialId of Uri
type CredentialType = CredentialType of string

type CredentialStatusId = CredentialStatusId of Uri
type CredentialStatusType = CredentialStatusType of string
type CredentialStatusSchema = {
    Id: CredentialStatusId
    Types: CredentialStatusType seq
}

type Claim = { 
    Id: ProfileId
}
 

type Credential = {
    Id: CredentialId
    Types: CredentialType seq
    Issuer: ProfileId
    Issued: DateTimeOffset
    Expires: DateTimeOffset option
    Claim: Claim
    CredentialStatus: CredentialStatusSchema option
    Proof: ProofSchema option
}

module Credential = 
    let create id types issuer issued expires claim credentialStatus proof =
        if not(Set.contains (CredentialType "Credential") types) then Error "'Types' must contain a 'Credential' type"
        elif Some issued > expires then Error "'Issued' must be earlier than 'Expires'"
        else Ok { Id = id; Types = types; Issuer = issuer; Issued = issued; Expires = expires; Claim = claim; CredentialStatus = credentialStatus; Proof = proof }


type Profile = { 
    Id: ProfileId
    Types: ProfileType seq
    Credential: Credential seq
    Proof: ProofSchema seq
}

module Profile =
    let create id types credential proof =
        if not(Set.contains (ProfileType "VerifiableProfile") types) then Error "'Types' must contain a 'VerifiableProfile' type"
        else Ok { Id = id; Types = types; Credential = credential; Proof = proof }