import html from "../core.js";
import { connect } from "../store.js";

// const connector = connect();

function TodoItem({todo,index,editIndex}) {
    const {title,completed} = todo;
    return html`
                <li class="${completed&&"completed"} ${editIndex === index && 'editing'}">
                    <div class="view">
                        <input 
                            class="toggle" 
                            type="checkbox" ${completed&&"checked"} 
                            onchange="dispatch('toggle',${index})"
                            />
                        <label ondblclick="dispatch('toEditMode',${index})">${title}</label>
                        <button class="destroy" onclick="dispatch('destroy',${index})"></button>
                    </div>
                    <input 
                        class="edit ed_${index}" 
                        value="${title}"
                        onkeyup="event.keyCode === 13 && dispatch('save',this.value.trim())||event.keyCode ===27 && dispatch('cancel')"
                        onblur= "dispatch('save',this.value.trim())"
                    />
                </li>`;
}
export default connect()(TodoItem);
