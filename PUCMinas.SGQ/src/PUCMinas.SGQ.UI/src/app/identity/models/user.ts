import { Guid } from 'guid-typescript';

export class User {
    email: string;
    password: string;
    expiresIn: number;
    loginUser: LoginUser;
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
