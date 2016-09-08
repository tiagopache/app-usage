import { Device } from './device';
import { Program } from './program';

export class Partner {
    public Id: number;

    public Name: string;

    public Devices: Device[];

    public Programs: Program[];
}