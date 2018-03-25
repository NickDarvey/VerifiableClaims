namespace NickDarvey.VerifiableClaims.Schema

open System


type ProofType = ProofType of string
type Proof = {
    Type: ProofType
}

type ProfileId = ProfileId of Uri
type ProfileType = ProfileType of string
type Profile = { 
    Id: ProfileId
    Types: ProfileType seq
    Proof: Proof option
}

module Profile =
    let EntityProfileType = ProfileType "Entity" 

    let create id types signature =
        if Seq.contains EntityProfileType types
        then { Id = id; Types = EntityProfileType::types; Proof = signature }
        else { Id = id; Types = types; Proof = signature }

type RevocationId = RevocationId of Uri
type RevocationType = RevocationType of string
type Revocation = {
    Id: RevocationId
    Types: RevocationType seq
}

type CredentialId = CredentialId of Uri
type CredentialType = CredentialType of string
type Claim = { Id: ProfileId }
type Credential = {
    Id: CredentialId
    Type: CredentialType seq
    Issuer: ProfileId
    Issued: DateTimeOffset
    Expires: DateTimeOffset option
    Claim: Claim
    Revocation: Revocation option
    Signature: Proof option
}
