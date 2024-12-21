export enum MessageType {
    Recieved = 'Recieved',
    Send = 'Send'
}

export interface LoggedInUserDetails {
    id: string,
    Name: string,
    email: string
}