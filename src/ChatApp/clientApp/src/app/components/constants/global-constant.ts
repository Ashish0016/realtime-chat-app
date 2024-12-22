export enum MessageType {
    Recieved = 'Recieved',
    Send = 'Send'
}

export interface LoggedInUserDetails {
    id: string | null,
    name: string | null,
    email: string | null
}