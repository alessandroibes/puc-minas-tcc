import { BehaviorSubject, Observable } from 'rxjs';
import { map } from "rxjs/operators";
import { Passo } from './models/passo';

export interface State {
    todolist: Passo[];
}

const state: State = {
    todolist: []
};

export class Store {
    private subject = new BehaviorSubject<State>(state);
    private store = this.subject.asObservable();

    get value() {
        return this.subject.value;
    }

    public getTodoList(): Observable<Passo[]> {
        return this.store.pipe(
            map(store => store.todolist));
    }

    set(name: string, state: any) {
        this.subject.next({
            ...this.value, [name]: state
        })
    }
}
