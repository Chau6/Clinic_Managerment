import { Account } from "./account.model";

export class Role{
    roleId: number;
    roleName: string;
    accounts: Account[];
}