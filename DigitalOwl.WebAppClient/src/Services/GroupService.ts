import api from "./Base/Api";
import {ModelGroup} from "../Model/ModelGroup";

export const GroupGetAllService = () =>
    api.get("/group");
export const GroupGetByIdService = (id: number) =>
    api.get("/group/" + id.toString());

export const GroupCreateService = (model: ModelGroup) =>
    api.post("/group/", model);

export const GroupUpdateService = (id: number, model: ModelGroup) =>
    api.put("/group/" + id.toString(), model);

export const GroupDeleteService = (id: number) =>
    api.delete("/group/" + id.toString());
