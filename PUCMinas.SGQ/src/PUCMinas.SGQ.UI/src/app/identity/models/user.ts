import { Guid } from 'guid-typescript';

export class User {
    username: string;
    email: string;
    password: string;
    expiresIn: number;
    loginUser: LoginUser;

    admin: boolean;
    gerente: boolean;
    operador: boolean;
    engenheiro: boolean;
    gestor: boolean;
}

export class LoginUser {
    acessToken: string;
    expiresIn: number;
    userToken: UserToken;
}

export class UserToken {
    id: Guid;
    email: string;
    claims: Claim[];
}

export class Claim {
    value: string;
    type: string;
}
