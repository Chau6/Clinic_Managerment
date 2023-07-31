import { Role } from "./role.model";

export class Account{
    accountId: number;
    firstname: string;
    lastname: string;
    email: string;
    password: string;
    phoneNumber: string;
    gender: string;
    addressId: number;
    avatar: string;
    roleId: number;
    role: Role;
    status: boolean;
    securityCode: string;
    createdAt: string;
    updatedAt: string;
}