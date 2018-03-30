namespace NickDarvey.VerifiableClaims.Schema

open System

module Security =
    type ProofType = ProofType of string
    type Proof = {
        Type: ProofType
    }

module Profile =
    type ProfileId = ProfileId of Uri
    type ProfileType = ProfileType of string


module Credential =
    type CredentialId = CredentialId of Uri
    type CredentialType = CredentialType of string

    type CredentialStatusId = CredentialStatusId of Uri
    type CredentialStatusType = CredentialStatusType of string
    type CredentialStatus = {
        Id: CredentialStatusId
        Types: CredentialStatusType seq
    }

    type Claim = { 
        Id: Profile.ProfileId
    }

type Credential = {
    Id: Credential.CredentialId
    Type: Credential.CredentialType seq
    Issuer: Profile.ProfileId
    Issued: DateTimeOffset
    Expires: DateTimeOffset option
    Claim: Credential.Claim
    CredentialStatus: Credential.CredentialStatus option
    Proof: Security.Proof option
}


type Profile = { 
    Id: Profile.ProfileId
    Types: Profile.ProfileType seq
    Credential: Credential seq option
    Proof: Security.Proof seq option
}

//module Profile =
//    let EntityProfileType = ProfileType "Entity" 

//    let create id types signature =
//        if Seq.contains EntityProfileType types
//        then { Id = id; Types = EntityProfileType::types; Proof = signature }
//        else { Id = id; Types = types; Proof = signature }
