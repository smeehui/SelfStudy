import storage from "./utils/storage.js";


const init = {
  todos: storage.get(),
  filter: "all",
  filters: {
    all: ()=>true,
    active: todo => !todo.completed,
    completed: todo => todo.completed
  },
  editIndex: null,
};

const actions = {
    add({todos},title){
        if(title){
            todos.push({title,completed:false})
            storage.set(todos)
        }
       let tID = setTimeout(()=>{
        document.querySelector(".new-todo").focus()
        return clearTimeout(tID)
       },100)
    },
    toggle({todos},index){
        const todo = todos[index];
        todo.completed = !todo.completed;
        storage.set(todos)
    },
    toggleAll ({todos},isCompleted){
        todos.forEach(todo => {
            todo.completed = isCompleted
        });
        storage.set(todos)
    },
    destroy ({todos},index){
        todos.splice(index,1);
        storage.set(todos)
    },
    switchFilter(state,filter){
        state.filter = filter;
    },
    clearCompleted(state){
        state.todos = state.todos.filter(state.filters.active)      
        storage.set(state.todos)
    },
    toEditMode(state,index){
        state.editIndex = index;
        let tID = setTimeout(()=>{
            document.querySelector(".ed_"+index).focus()
            return clearTimeout(tID)
           },100)
    },
    save (state,title){
        let editIndex = state.editIndex;
        if(editIndex!=null){
            state.todos[editIndex].title = title;
            storage.set(state.todos)
        }else if(!title){
            this.destroy(state,state.editIndex)
        }
        state.editIndex = null;
    },
    cancel (state){
        if(state.editIndex!=null){
            state.editIndex = null;
        }
    }

}
export default function reducer(state = init, action, args) {
    actions[action] && actions[action](state,...args)
    return state;
}
