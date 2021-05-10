import { Address } from "./address";
import { JobTitleInterested } from "./job-interesteds";
import { Language } from "./language";
import { Phone } from "./phone";

export class Person {
    id: string;
    nationalityId: string | null;
    maritalStatusId: string | null;
    specialNeedsId: string | null;
    addressId: string | null;
    religionId: string | null;
    firstName: string;
    lastName: string;
    fullName: string;
    birthDate: string;
    gender: number;
    cpf: string;
    profileBase64: string;
    ppd: boolean;
    goal: string;
    summary: string;
    idGroupApse: number | null;
    idGroupApseGuid: string | null;
    grupoAPSeIdEmpresa: number | null;
    downloadPPD: boolean | null;
    linkedIn: string;
    createdDate: string;
    updatedDate: string;
    deleted: boolean;
    jobTitleInteresteds: JobTitleInterested[];
    phones: Phone[];
    languages: Language[];
    address: Address
}