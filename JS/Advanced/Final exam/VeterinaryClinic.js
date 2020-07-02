class VeterinaryClinic {
    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = [];

        this.totalProfit = 0;
        this.currentWordLoad = 0;
    }

    newCustomer(ownerName, petName, kind, procedures) {

        let currentOwner = this.clients.find(c => c.name == ownerName);

        if (currentOwner !== undefined) {

            var currentPet = currentOwner.pets.find(p => p.name == petName);
        }

        if (this.currentWordLoad >= this.capacity) {

            throw new Error('Sorry, we are not able to accept more patients!');

        } else if (currentPet !== undefined && currentOwner !== undefined) {

            if (currentPet.procedures.length > 0) {

                throw new Error(`This pet is already registered under ${currentOwner.name} name! ${currentPet.name} is on our lists, waiting for ${currentPet.procedures.map(p => `p`).join(', ')}.`);
            }

        } else if (currentOwner === undefined) {

            let owner = {

                name: ownerName,
                pets: []
            };

            let pet = {

                name: petName,
                kind: kind,
                procedures: procedures,
            }

            this.currentWordLoad++;

            owner.pets.push(pet);

            this.clients.push(owner);

            return `Welcome ${petName}!`;

        } else {

            let newPet = {

                name: petName,
                kind: kind,
                procedures: procedures,
            }

            this.currentWordLoad++;

            currentOwner.pets.push(newPet);

            return `Welcome ${petName}!`;
        }

    }

    onLeaving(ownerName, petName) {

        let currentOwner = this.clients.find(c => c.name == ownerName);
        let currentPet = currentOwner.pets.find(p => p.name == petName);

        if (currentOwner === undefined) {

            throw new Error(`Sorry, there is no such client!`);

        } else if (currentPet === undefined || currentPet.procedures.length == 0) {

            throw new Error(`Sorry, there are no procedures for ${petName}`);

        } else {

            for (let i = 0; i < currentPet.procedures.length; i++) {

                this.totalProfit += 500;
            }

            currentPet.procedures = [];

            this.currentWordLoad--;

            return `Goodbye ${petName}. Stay safe!`;
        }
    }

    toString() {

        let result = [
            `${this.clinicName} is ${Math.floor((this.currentWordLoad / this.capacity) * 100)}% busy today!`,
            `Total profit: ${this.totalProfit.toFixed(2)}$`,
            `${this.clients.sort((a, b) => a.name.localeCompare(b.name)).map(c => `${c.name} with:\n${c.pets.sort((a, b) => a.name.localeCompare(b.name)).map(p => `---${p.name} - a ${p.kind.toLowerCase()} that needs: ${p.procedures.map(pr => `${pr}`).join(', ')}`).join('\n')}`).join('\n')}`
        ]

        return result.join('\n');
    }
}

let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B']));
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString());
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']);
console.log(clinic.toString());



