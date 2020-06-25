import api from "./Base/Api";
import {ModelCreatePoll, ModelPoll} from "../Model/ModelPoll";

export const PollGetAllService = () =>
    api.get("/poll");

export const PollGetByIdService = (id: number) =>
    api.get("/poll/" + id.toString());

export const PollCreateService = (model: ModelCreatePoll) =>
    api.post("/poll/", model);

export const PollUpdateService = (id: number, model: ModelPoll) =>
    api.put("/poll/" + id.toString(), model);

export const PollDeleteService = (id: number) =>
    api.delete("/poll/" + id.toString());
