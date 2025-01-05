export enum MessageType {
    Recieved = 'Recieved',
    Send = 'Send'
}

export interface ChatContact {
    avatar: string,
    name: string,
    lastMessage: string
}

export interface LoggedInUserDetails {
    id: string | null,
    name: string | null,
    email: string | null
}