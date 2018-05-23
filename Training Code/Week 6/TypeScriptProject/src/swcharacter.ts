export class SWCharacter {
    constructor(private name: string, private hair_color: string) {
    }

    public description(): string {
        return this.name + ", with hair color " + this.hair_color;
    }
}
